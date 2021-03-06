using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;

namespace SEDCWebApplication.DAL.data.Implementations
{
    public class OrderDAL : BaseDAL, IOrderDAL
    {
  
  
        protected override string COLUMN_PREFIX {
            get { return ColumnPrefixConstants.EMP; }
        }


        public void Save(Order item)
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

        public Order GetById(int id)
        {
            SqlConnection cn = ConnectionGet();

            Order result = null;

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_GetById";

            this.ParamValueTypeNonNullableValueSet(cmd, id, "@OrderId", SqlDbType.Int);

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
        public List<Order> GetByEmployeeId(int id)
        {
            SqlConnection cn = ConnectionGet();

            Order result = null;
            List<Order> results = new List<Order>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_GetByEmployeeId";

            this.ParamValueTypeNonNullableValueSet(cmd, id, "@EmployeeId", SqlDbType.Int);

            try {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    result = Create(reader);
                    results.Add(result);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                cn.Close();
            }
            return results;
        }

        private void Add(Order item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_Ins";

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

        private void Update(Order item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_Upd";

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

        public List<Order> SearchOrders(string searchParam)
        {
            SqlConnection cn = ConnectionGet();

            Order result = null;
            List<Order> results = new List<Order>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_Search";

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

        public List<Order> GetAll(int skip, int take)
        {
            SqlConnection cn = ConnectionGet();

            Order result = null;
            List<Order> results = new List<Order>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Order_GetAll";

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


        private void CommonParametersAdd(Order item, SqlCommand cmd)
        {

            this.ParamStringNullableValueSet(cmd, item.Number, "@OrderNumber", SqlDbType.NVarChar, 50);
            /*this.ParamStringNullableValueSet(cmd, item.UserName, "@UserName", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.Password, "@Password", SqlDbType.NVarChar, 50);
            this.ParamStringNonNullableValueSet(cmd, item.Name, "@OrderName", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.Gender, "@Gender", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.ImagePath, "@ImagePath", SqlDbType.NVarChar, 200);
            this.ParamValueTypeNonNullableValueSet(cmd, item.RoleId, "@RoleId", SqlDbType.Int);
            this.ParamValueTypeNonNullableValueSet(cmd, item.DateOfBirth, "@DateOfBirth", SqlDbType.Date);*/
        }

        private Order Create(IDataReader reader)
        {
            Order item = new Order(ReaderColumnReadNullableValueType<Int32>(reader, "ID", COLUMN_PREFIX));

            item.Number = ReaderColumnReadObject<string>(reader, "OrderNumber", COLUMN_PREFIX);
            item.TotalAmount = ReaderColumnReadValueType<decimal>(reader, "TotalAmount", COLUMN_PREFIX);
            item.Status = ReaderColumnReadValueType<int>(reader, "OrderStatusId", COLUMN_PREFIX);
            item.Date = ReaderColumnReadValueType<DateTime>(reader, "OrderDate", COLUMN_PREFIX);

            return item;
        }
    }
}
