using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLayer
{
    public class ClsDataLayer
    {

        private string conn = ConfigurationManager.ConnectionStrings["ConString"].ToString();



        public void InsertUpdateDeleteSQLString(string sqlstring)

        {
            try
            {
                SqlConnection objsqlconn = new SqlConnection(conn);

                objsqlconn.Open();

                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);

                objcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public object ExecuteSqlString(string sqlstring)

        {
            SqlConnection objsqlconn = new SqlConnection(conn);

            objsqlconn.Open();

            DataSet ds = new DataSet();

            SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);

            objAdp.Fill(ds);

            return ds;

        }

        public bool CheckAlreadyExist(string sqlstring)

        {
            bool isExist = false;
            SqlConnection objsqlconn = new SqlConnection(conn);

            objsqlconn.Open();

            SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            int numrows = (int)objcmd.ExecuteScalar();
            if (numrows > 0)
                isExist = true;

            return isExist;

        }

        #region Branch
        public bool UpdateBranch(Branch branch)

        {

            DataSet ds = new DataSet();

            string sql = "Update Branch_Master set Name='" + branch.Name + "',STName = '" + branch.STName + "',Address1= '" + branch.Address1 + "',Address2 = '" + branch.Address2 + "',Address3 = '" + branch.Address3 + "',Address4 = '" + branch.Address4 + "',PhoneNo = '" + branch.PhoneNo + "',Email = '" + branch.Email + "' ,Prefix = '" + branch.Prefix1 + "',Prefix1 = '" + branch.Prefix2 + "',GSTIN = '" + branch.GSTIN + "' Where ID = '" + branch.ID + "' ";

            InsertUpdateDeleteSQLString(sql);

            return true;

        }

        public List<Branch> LoadBranch()

        {

            DataSet ds = new DataSet();

            string sql = "SELECT * from Branch_Master order by Id";
            ds = (DataSet)ExecuteSqlString(sql);
            List<Branch> list = ds.Tables[0].AsEnumerable().Select(r => new Branch()
            {
                Name = (string)r["Name"],
                STName = (string)r["STName"],
                Address1 = (string)r["Address1"],
                Address2 = (string)r["Address2"],
                Address3 = (string)r["Address3"],
                Address4 = (string)r["Address4"],
                Email = (string)r["Email"],

                PhoneNo = (string)r["PhoneNo"],
                Prefix1 = (string)r["Prefix"],
                Prefix2 = (string)r["Prefix1"],
                GSTIN = (string)r["GSTIN"],
                ID = (Int32)r["ID"]


            }
             ).ToList();
            return list;

        }

        public void DeleteBranch(int BranchID)

        {

            DataSet ds = new DataSet();

            string sql = "Delete From Branch_Master Where ID = '" + BranchID + "' ";

            InsertUpdateDeleteSQLString(sql);

        }

        public void AddNewBranch(Branch objBranch)

        {


            string sql = "INSERT into Branch_Master (Name,STName,Address1,Address2,Address3,Address4,PhoneNo,Email,Prefix,Prefix1,GSTIN) VALUES ('" + objBranch.Name + "','" + objBranch.STName + "','" + objBranch.Address1 + "','" + objBranch.Address2 + "','" + objBranch.Address3 + "','" + objBranch.Address4 + "','" + objBranch.PhoneNo + "','" + objBranch.Email + "','" + objBranch.Prefix1 + "','" + objBranch.Prefix2 + "','" + objBranch.GSTIN + "')";

            InsertUpdateDeleteSQLString(sql);

        }

        #endregion

        #region Particulars
        public bool UpdateParticulars(Particular particular)

        {

            DataSet ds = new DataSet();

            string sql = "Update Particulars set LRNO ='" + particular.LRNO + "',SNO = '" + particular.SNO + "',Particulars= '" + particular.Particulars + "',Quantity = '" + particular.Quantity + "',Netrate = '" + particular.NetRate + "',Amount = '" + particular.Amount+ "' Where ID = '" + particular.ID + "'";

            InsertUpdateDeleteSQLString(sql);

            return true;

        }

        public List<Particular> LoadParticulars()

        {

            DataSet ds = new DataSet();

            string sql = "SELECT * from Particulars order by Id";
            ds = (DataSet)ExecuteSqlString(sql);
            List<Particular> list = ds.Tables[0].AsEnumerable().Select(r => new Particular()
            {
                LRNO = (string)r["LRNO"],
                SNO = (Int32)r["SNO"],
                Particulars = (string)r["Particulars"],
                Quantity = (Int32)r["Quantity"],
                NetRate = (decimal)r["Netrate"],
                Amount = (decimal)r["Amount"],
                ID = (Int32)r["ID"]


            }
             ).ToList();
            return list;

        }

        public void DeleteParticulars(int particularID)

        {

            DataSet ds = new DataSet();

            string sql = "Delete From Particulars Where ID = '" + particularID + "' ";

            InsertUpdateDeleteSQLString(sql);

        }

        public void AddNewParticular(Particular objBranch)

        {
            string sql = "INSERT into Particulars (LRNO,SNO,Particulars,Quantity,Netrate,Amount) VALUES ('" + objBranch.LRNO + "','" + objBranch.SNO     + "','" + objBranch.Particulars + "','" + objBranch.Quantity + "','" + objBranch.NetRate + "','" + objBranch.Amount + "')";

            InsertUpdateDeleteSQLString(sql);

        }


        #endregion
        #region  Item

        public void AddNewItem(Item objItem)
        {
            string sql = "INSERT into Item_Master (Name,ShortName,SRate) VALUES ('" + objItem.Name + "','" + objItem.ShortName + "','" + objItem.SRate + "')";
            InsertUpdateDeleteSQLString(sql);
        }
        public bool UpdateItem(Item item)

        {

            // DataSet ds = new DataSet();

            string sql = "Update Item_Master set Name='" + item.Name + "',ShortName = '" + item.ShortName + "',SRate= '" + item.SRate + "' Where ID = '" + item.ID + "' ";

            InsertUpdateDeleteSQLString(sql);

            return true;

        }
        public List<Item> LoadItem()

        {

            DataSet ds = new DataSet();

            string sql = "SELECT * from Item_Master order by Id";
            ds = (DataSet)ExecuteSqlString(sql);
            List<Item> list = ds.Tables[0].AsEnumerable().Select(r => new Item()
            {
                Name = (string)r["Name"],
                ShortName = (string)r["ShortName"],
                SRate = (decimal)r["SRate"],
                ID = (Int32)r["ID"]


            }
             ).ToList();
            return list;

        }
        public void DeleteItem(int ItemID)

        {

            DataSet ds = new DataSet();

            string sql = "Delete From Item_Master Where ID = '" + ItemID + "' ";

            InsertUpdateDeleteSQLString(sql);

        }

        #endregion

        #region  Vehicle

        public void AddNewVehicle(Vehicle objItem)
        {
            string sql = "INSERT into Vehicle_Master (Name,STName,Number) VALUES ('" + objItem.Name + "','" + objItem.STName + "','" + objItem.Number + "')";
            InsertUpdateDeleteSQLString(sql);
        }
        public bool UpdateVehicle(Vehicle item)

        {

            // DataSet ds = new DataSet();

            string sql = "Update Vehicle_Master set Name='" + item.Name + "',STName = '" + item.STName + "',Number= '" + item.Number + "' Where ID = '" + item.ID + "' ";

            InsertUpdateDeleteSQLString(sql);

            return true;

        }
        public List<Vehicle> LoadVehicle()

        {

            DataSet ds = new DataSet();

            string sql = "SELECT * from Vehicle_Master order by Id";
            ds = (DataSet)ExecuteSqlString(sql);
            List<Vehicle> list = ds.Tables[0].AsEnumerable().Select(r => new Vehicle()
            {
                Name = (string)r["Name"],
                STName = (string)r["STName"],
                Number = (string)r["Number"],
                ID = (Int32)r["ID"]


            }
             ).ToList();
            return list;

        }
        public void DeleteVehicle(int ItemID)

        {

            DataSet ds = new DataSet();

            string sql = "Delete From Vehicle_Master Where ID = '" + ItemID + "' ";

            InsertUpdateDeleteSQLString(sql);

        }

        #endregion

        #region Users
        public string AddNewUser(Users objUsers)

        {
            try
            {
                if (CheckAlreadyExist("select Count(*) from Users where UserName = '" + objUsers.UserName + "'"))
                    return "USER ALREADY EXIST";

                string sql = "INSERT into Users (Name,UserName,Password,IsDefaultPassword,Role,Permission,BranchID) VALUES ('" + objUsers.Name + "','" + objUsers.UserName + "','" + objUsers.Password + "','" + objUsers.IsDefaultPassword + "','" + objUsers.Role + "','" + objUsers.Permission + "','" + objUsers.BranchID + "')";

                InsertUpdateDeleteSQLString(sql);

                return "SUCESS";
            }
            catch (Exception ex)
            {

                return "FAILUER";
            }


        }

        public bool ResetPasword(Users objUsers)
        {
            string sql = "Update Users set Password='" + objUsers.Password + "',IsDefaultPassword = '" + objUsers.IsDefaultPassword + "' Where ID = '" + objUsers.ID + "' ";

            InsertUpdateDeleteSQLString(sql);

            return true;
        }
        #endregion



        #region  Party

        public void AddNewParty(Party objParty)
        {
            string sql = "INSERT into Party_Master (Name,Place,PhoneNo,GSTIN) VALUES ('" + objParty.Name + "','" + objParty.Place + "','" + objParty.PhoneNo + "','" + objParty.GSTIN + "')";
            InsertUpdateDeleteSQLString(sql);
        }
        public bool Updateparty(Party item)

        {

            // DataSet ds = new DataSet();

            string sql = "Update Party_Master set Name='" + item.Name + "',Place = '" + item.Place + "',PhoneNo= '" + item.PhoneNo + "',GSTIN= '" + item.GSTIN + "' Where ID = '" + item.ID + "' ";

            InsertUpdateDeleteSQLString(sql);

            return true;

        }
        public List<Party> LoadParty()

        {

            DataSet ds = new DataSet();

            string sql = "SELECT * from Party_Master order by Id";
            ds = (DataSet)ExecuteSqlString(sql);
            List<Party> list = ds.Tables[0].AsEnumerable().Select(r => new Party()
            {
                Name = (string)r["Name"],
                Place = (string)r["Place"],
                PhoneNo = (string)r["PhoneNo"],
                GSTIN = (string)r["GSTIN"],
                ID = (Int32)r["ID"]


            }
             ).ToList();
            return list;

        }
        public void DeleteParty(int ItemID)

        {

            DataSet ds = new DataSet();

            string sql = "Delete From Party_Master Where ID = '" + ItemID + "' ";

            InsertUpdateDeleteSQLString(sql);

        }

        #endregion

        #region LREntry

        public void AddNewLREntry(LREntry objItem)
        {
            try
            {
                string sql = "INSERT into LREntry (BrachID,LRNO,GST,Direct,LRDateTime,FromParty,F_Place,F_GSTIN,F_MobileNo,ToParty,T_Place,T_GSTIN,T_MobileNo,BaleNo,NatureOfGoods,Others,No_Of_Articles,Frieght,LodingCharge,UnloadingCharge,DDCharge,TotalAmount,CGST,SGST,Roundof,NetAmount, Weight,Pay,Delivary_Type" +

             ") "
             + "VALUES " + "('"
             + objItem.BrachID + "','" + objItem.LRNO + "','" + objItem.GST + "','"
             + objItem.Direct + "','" + objItem.LRDateTime + "','" + objItem.FromParty + "','"
             + objItem.F_Place + "','" + objItem.F_GSTIN + "','" + objItem.F_MobileNo + "','"
             + objItem.ToParty + "','" + objItem.T_Place + "','" + objItem.T_GSTIN + "','"
             + objItem.T_MobileNo + "','" + objItem.BaleNo + "','" + objItem.NatureOfGoods + "','"
             + objItem.Others + "','" + objItem.No_Of_Articles + "','" + objItem.Frieght + "','"
             + objItem.LoadingCharge + "','" + objItem.UnloadingCharge + "','" + objItem.DDCharge + "','"
             + objItem.TotalAmount + "','" + objItem.CGST + "','" + objItem.SGST + "','"
             + objItem.RoundOf + "','" + objItem.NetAmount + "','" + objItem.Weight + "','"
             + objItem.Pay + "','" + objItem.DeliveryType + "')";
                InsertUpdateDeleteSQLString(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion


        #region Login

        public Users login1(string userName, string Password)
        {
            string sql = "select top 1 *  From Users Where userName = '" + userName + "' and Password = '" + Password + "' ";
            SqlConnection objsqlconn = new SqlConnection(conn);

            objsqlconn.Open();

            SqlCommand cmd = new SqlCommand(sql, objsqlconn);
            Users users = new Users();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                users.ID = Convert.ToInt32(sqlDataReader["ID"].ToString());
                users.Name = sqlDataReader["Name"].ToString();
                users.UserName = sqlDataReader["UserName"].ToString();
                users.BranchID = Convert.ToInt32(sqlDataReader["BranchID"].ToString());
                users.IsDefaultPassword = Convert.ToBoolean(sqlDataReader["IsDefaultPassword"].ToString());
                users.Role = sqlDataReader["Role"].ToString();
                users.Permission = sqlDataReader["Permission"].ToString();
            }
            return users;

        }

        public Users login(string userName, string Password)
        {
           // string sql = "select top 1 *  From Users Where userName = '" + userName + "' and Password = '" + Password + "' ";
            SqlConnection objsqlconn = new SqlConnection(conn);
            string procedure = "sp_Login";

            objsqlconn.Open();

            SqlCommand cmd = new SqlCommand(procedure, objsqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value=userName;
            //cmd.Parameters["UserName"].Value = userName;
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value=Password;
           // cmd.Parameters["Password"].Value = Password;
            Users users = new Users();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                users.ID = Convert.ToInt32(sqlDataReader["ID"].ToString());
                users.Name = sqlDataReader["Name"].ToString();
                users.UserName = sqlDataReader["UserName"].ToString();
                users.BranchID = Convert.ToInt32(sqlDataReader["BranchID"].ToString());
                users.IsDefaultPassword = Convert.ToBoolean(sqlDataReader["IsDefaultPassword"].ToString());
                users.Role = sqlDataReader["Role"].ToString();
                users.Permission = sqlDataReader["Permission"].ToString();
                users.prefix= sqlDataReader["prefix"].ToString();
                users.prefix1 = sqlDataReader["prefix1"].ToString();
            }
            return users;

        }

        #endregion
    }
}
