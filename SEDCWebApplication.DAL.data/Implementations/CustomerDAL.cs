using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;

namespace SEDCWebApplication.DAL.data.Implementations
{
    public class CustomerDAL : BaseDAL, ICustomerDAL
    {
        protected override string COLUMN_PREFIX {
            get { return ColumnPrefixConstants.CUS; }
        }
        public void Save(Customer item)
        {
            switch (item.EntityState) {
                case EntityStateEnum.New:
                    this.Add(item);
                    break;
                case EntityStateEnum.Updated:
                    this.Update(item);
                    break;
                case EntityStateEnum.Loaded:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("EntityState is invalid: Value: {0}", item.EntityState));
            }
            item.EntityState = EntityStateEnum.Loaded;
        }
        public void Add(Customer item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Customer_Ins";

            CommonParametersAdd(item, cmd);

            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@ID";
            prm.SqlDbType = SqlDbType.Int;
            prm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prm);

            try {
                cn.Open();

                cmd.ExecuteNonQuery();

                item.Id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            }
            catch (Exception ex) {
                //DMLogger.Singleton.LogError(ex, item);
                throw;
            }
            finally {
                cn.Close();
            }
        }

        public List<Customer> GetAll(int skip, int take)
        {
            SqlConnection cn = ConnectionGet();

            Customer result = null;
            List<Customer> results = new List<Customer>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Customer_GetAll";

            this.ParamValueTypeNonNullableValueSet(cmd, skip, "@RowsToSkip", SqlDbType.Int);
            this.ParamValueTypeNonNullableValueSet(cmd, take, "@RowsToTake", SqlDbType.Int);

            try {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                   result = Create(reader);
                    results.Add(result);
                }
            }
            catch (Exception ex) {
                //DMLogger.Singleton.LogError(LogCategories.SECURITY, ex);
                throw;
            }
            finally {
                cn.Close();
            }
            return results;
        }

        public Customer GetById(int id)
        {
            SqlConnection cn = ConnectionGet();

            Customer result = null;

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Customer_GetById";

            this.ParamValueTypeNonNullableValueSet(cmd, id, "@CustomerId", SqlDbType.Int);

            try {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    result = Create(reader);
                }
            }
            catch (Exception ex) {
                //DMLogger.Singleton.LogError(LogCategories.SECURITY, ex);
                throw;
            }
            finally {
                cn.Close();
            }
            return result;
        }

        private void Update(Customer item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Employee_Upd";

            CommonParametersAdd(item, cmd);

            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@ID";
            prm.SqlDbType = SqlDbType.Int;
            prm.Value = item.Id.Value;
            cmd.Parameters.Add(prm);

            try {
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                //DMLogger.Singleton.LogError(ex, item);
                throw;
            }
            finally {
                cn.Close();
            }
        }

        public List<Customer> SearchCustomers(string searchParam)
        {
            SqlConnection cn = ConnectionGet();

            Customer result = null;
            List<Customer> results = new List<Customer>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Customer_Search";

            this.ParamStringNullableValueSet(cmd, searchParam, "@SearchParam", SqlDbType.NVarChar, 50);

            try {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    result = Create(reader);
                    results.Add(result);
                }
            }
            catch (Exception ex) {
                //DMLogger.Singleton.LogError(LogCategories.SECURITY, ex);
                throw;
            }
            finally {
                cn.Close();
            }
            return results;
        }
        private void CommonParametersAdd(Customer item, SqlCommand cmd)
        {
            this.ParamStringNullableValueSet(cmd, item.UserName, "@UserName", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.Password, "@Password", SqlDbType.NVarChar, 50);
            this.ParamStringNonNullableValueSet(cmd, item.Name, "@CustomerName", SqlDbType.NVarChar, 50);
            this.ParamValueTypeNonNullableValueSet(cmd, item.ContactId, "@ContactId", SqlDbType.Int);
          
        }

        private Customer Create (IDataReader reader)
        {
            Customer item = new Customer(ReaderColumnReadNullableValueType<Int32>(reader, "ID", COLUMN_PREFIX));

            item.Name = ReaderColumnReadObject<string>(reader, "CustomerName", COLUMN_PREFIX);
            //item.Email = ReaderColumnReadObject<string>(reader, "Username", COLUMN_PREFIX);
            //item.Address = ReaderColumnReadObject<string>(reader, "Address", COLUMN_PREFIX);
            item.ContactId = ReaderColumnReadValueType<int>(reader, "ContactId", COLUMN_PREFIX);

            return item;
        }
    
}
}
