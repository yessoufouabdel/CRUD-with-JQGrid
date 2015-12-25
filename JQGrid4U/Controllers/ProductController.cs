using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQGrid4U.BL;

namespace JQGrid4U.Controllers
{
    public class ProductController : Controller
    {
        ProductBusinessLogic ProductBL = new ProductBusinessLogic();
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SelectProduct()
        {
            return Json(ProductBL.Products.ToList(), JsonRequestBehavior.AllowGet);
        }

        public string InsertProduct([Bind(Exclude = "ProductID")]Product Product)
        {
            string msg;
            if(ModelState.IsValid)
            {
                if(ProductBL.InsertProduct(Product)>0)
                {
                    msg = "Data Inserted Successfully";
                }
                else
                {
                    msg = "Error. Could Not Insert Data";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }

            return msg;
        }

        public string UpdateProduct(Product Product)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (ProductBL.UpdateProduct(Product) > 0)
                {
                    msg = "Data Updated Successfully";
                }
                else
                {
                    msg = "Error. Could Not Update Data";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }

            return msg;
        }


        public string DeleteProduct(int Id)
        {
            string msg;

            if (ProductBL.DeleteProduct(Id) > 0)
            {
                msg = "Data Deleted Successfully";
            }
            else
            {
                msg = "Error. Could Not Delete Data";
            }

            return msg;
        }
	}
}