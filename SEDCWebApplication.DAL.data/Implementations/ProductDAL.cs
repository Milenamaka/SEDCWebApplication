using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;

namespace SEDCWebApplication.DAL.data.Implementations
{
    public class ProductDAL : BaseDAL, IProductDAL
    {

        protected override string COLUMN_PREFIX {
            get { return ColumnPrefixConstants.PROD; }
        }


        public void Save(Product item)
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

        public Product GetById(int id)
        {
            SqlConnection cn = ConnectionGet();

            Product result = null;

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_GetById";

            this.ParamValueTypeNonNullableValueSet(cmd, id, "@ProductId", SqlDbType.Int);

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


        private void Add(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Ins";

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

        private void Update(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Upd";

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
        public void Delete(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Del";

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
        public List<Product> SearchProducts(string searchParam)
        {
            SqlConnection cn = ConnectionGet();

            Product result = null;
            List<Product> results = new List<Product>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Search";

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

        public List<Product> GetAllProducts(int skip, int take)
        {
            SqlConnection cn = ConnectionGet();

            Product result = null;
            List<Product> results = new List<Product>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_GetAll";

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

       
        private void CommonParametersAdd(Product item, SqlCommand cmd)
        {

            this.ParamStringNonNullableValueSet(cmd, item.ProductName, "@ProductName", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.Size, "@Size", SqlDbType.NVarChar, 50);
            this.ParamStringNullableValueSet(cmd, item.ImagePath, "@ImagePath", SqlDbType.NVarChar, 255);
            this.ParamStringNullableValueSet(cmd, item.Description, "@Description", SqlDbType.NVarChar, 255);
            this.ParamValueTypeNonNullableValueSet(cmd, item.IsDiscounted, "@IsDiscounted", SqlDbType.Bit);
            this.ParamValueTypeNonNullableValueSet(cmd, item.UnitPrice, "@UnitPrice", SqlDbType.Int);

        }

        private Product Create(IDataReader reader)
        {
            Product item = new Product(ReaderColumnReadNullableValueType<Int32>(reader, "ID", COLUMN_PREFIX));

            item.ProductName = ReaderColumnReadObject<string>(reader, "ProductName", COLUMN_PREFIX);
            item.Size = ReaderColumnReadObject<string>(reader, "Size", COLUMN_PREFIX);
            item.ImagePath = ReaderColumnReadObject<string>(reader, "ImagePath", COLUMN_PREFIX);
            item.Description = ReaderColumnReadObject<string>(reader, "Description", COLUMN_PREFIX);
            item.IsDiscounted = ReaderColumnReadValueType<Boolean>(reader, "IsDiscounted", COLUMN_PREFIX);
            item.UnitPrice = ReaderColumnReadValueType<int>(reader, "UnitPrice", COLUMN_PREFIX);


            return item;
        }
    }
}
 
