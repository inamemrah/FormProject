using System.Web.Mvc;
using Web.Models;
using Data.DAL;
using Data.Entity;
using System;
using System.Linq;
using Web.Core;
using System.Web;

namespace Web.Controllers
{
    public class FormController : MyController
    {
        public ActionResult FormPage()
        {
            FormDAL formDAL = new FormDAL();

            var forms = formDAL.Get();
            ViewBag.Message = forms;
            ViewBag.NumTimes = forms.Count();

            return View();
        }

        [HttpPost]
        public ActionResult createForm(FormModel form)
        {
            try
            {

                var validationControl = Validation(form.FirstName, form.LastName, form.Age);
                var reqCookies = cookieControl();
                
                if (validationControl == true && reqCookies != null)
                {
                    int lastInsertFormId = InsertForm(form);
                    InsertFormField(form, lastInsertFormId);
                }
                
            }
            catch (System.Exception)
            {
                return Json("ERROR");
            }
            return Json("Success");
        }

        public int InsertForm(FormModel form)
        {
            FormDAL formDAL = new FormDAL();

            var reqCookies = cookieControl();

            var newForm = new Form()
            {
                Name = form.Name,
                Description = form.Description,
                CreatedAt = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                CreatedBy = Convert.ToInt32(reqCookies["Id"])
            };
            formDAL.Insert(newForm);

            return newForm.Id;
        }

        public void InsertFormField(FormModel form, int id)
        {
            FormFieldDAL formFieldDAL = new FormFieldDAL();

            var newFormField = new FormField()
            {
                FormId = id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Age = form.Age
            };
            formFieldDAL.Insert(newFormField);
        }
        
        [HttpPost]
        public ActionResult formDetail(int id)
        {
            FormDAL formDAL = new FormDAL();
            FormFieldDAL formFieldDAL = new FormFieldDAL();

            var form = formDAL.GetById(id);
            var field = formFieldDAL.GetById(id);

            FormModel formModel = new FormModel()
            {
                Id = id,
                Name = form.Name,
                Description = form.Description,
                FirstName = field.FirstName,
                LastName = field.LastName,
                Age = field.Age
            };

            return Json(formModel);
        }

        public bool Validation(string FirstName, string LastName, int Age)
        {
            if (FirstName == null || LastName == null || Age == null)
            {
                return false;
            }
            return true;
        }

        public HttpCookie cookieControl()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            return reqCookies;
        }
    }
}