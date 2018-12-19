using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsBusinessLayer
    {
        public ClsDataLayer objdl = new ClsDataLayer();


        #region Branch
        public void AddNewBranchName(Branch branch)
        {
            objdl.AddNewBranch(branch);
        }

        public List<DatabaseLayer.Branch> LoadBranch()
        {
            return objdl.LoadBranch();
        }

        public void DeleteBranch(int id)
        {
            objdl.DeleteBranch(id);
        }

        public bool updateBranch(Branch branch)
        {
            return objdl.UpdateBranch(branch);
        }

        #endregion

        #region Item
        public void AddNewItem(Item item)
        {
            objdl.AddNewItem(item);
        }

        public List<DatabaseLayer.Item> LoadItem()
        {
            return objdl.LoadItem();
        }

        public void DeleteItem(int id)
        {
            objdl.DeleteItem(id);
        }

        public bool updateItem(Item item)
        {
            return objdl.UpdateItem(item);
        }
        #endregion

        #region Vehicle
        public void AddNewVehicle(Vehicle item)
        {
            objdl.AddNewVehicle(item);
        }

        public List<DatabaseLayer.Vehicle> LoadVehicle()
        {
            return objdl.LoadVehicle();
        }

        public void DeleteVehicle(int id)
        {
            objdl.DeleteVehicle(id);
        }

        public bool updateVehicle(Vehicle item)
        {
            return objdl.UpdateVehicle(item);
        }
        #endregion

        #region USers

        public string AddNewUser(Users user)
        {
            return objdl.AddNewUser(user);
        }
        public bool ForcePasswordChange(Users user)
        {
            return objdl.ResetPasword(user);
        }

        #endregion

        #region login
        public Users login(string userName, string Password)
        {
            return objdl.login(userName, Password);
        }
        #endregion

        #region Particulars
        public void AddNewParticular(Particular particular)
        {
            objdl.AddNewParticular(particular);
        }

        public List<DatabaseLayer.Particular> LoadParticular()
        {
            return objdl.LoadParticulars();
        }

        public void DeleteParticular(int id)
        {
            objdl.DeleteParticulars(id);
        }

        public bool UpdateParticular(Particular particular)
        {
            return objdl.UpdateParticulars(particular);
        }
        #endregion

        #region Party

        public void AddParty(Party item)
        {
            objdl.AddNewParty(item);
        }

   

        public void DeleteParty(int id)
        {
            objdl.DeleteParty(id);
        }

        public bool updateParty(Party item)
        {
            return objdl.Updateparty(item);
        }
        public List<Party> LoadParty()
        {
            return objdl.LoadParty();
        }
        #endregion
    }
}
