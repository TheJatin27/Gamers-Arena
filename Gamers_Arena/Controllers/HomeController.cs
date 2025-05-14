using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Gamers_Arena.Models;
using System.Web.UI.WebControls;

namespace Gamers_Arena.Controllers
{
    public class HomeController : Controller

    {
     

        SqlConnection connection = new SqlConnection("Data Source=THE-JATIN;Initial Catalog=\"Gamers Arena\";Integrated Security=True");

         
        db database = new db();
      


        public ActionResult Index()
        {


            String command = "select top 5 * from add_game order by name desc";


            DataTable dt = database.SelectStatment(command);
            ViewBag.ga = dt;



            String comman = "select top 4 * from add_game order by sr desc";


            DataTable jt = database.SelectStatment(comman);
            ViewBag.new_gam = jt;


            String comm = "select top 3 * from tournment order by serial desc";


            DataTable at = database.SelectStatment(comm);
            ViewBag.tr = at;


            return View();
        }


        public ActionResult Login()
        {

            return View();

        }
        [HttpPost]

        public ActionResult Login(string mail, string pass)
        {
            string command = "select * from sin_up where username = '" + mail + "'and password = '" + pass + "'";





            DataTable dt = database.SelectStatment(command);

            if (dt.Rows.Count > 0)
            {

                Session["User"] = mail;

                return RedirectToAction("profile", "user"+
                    "");


            }

            else
            {

                return Content("<script>alert('bhag yaha se')</script>");


            }




        }





        public ActionResult Signup()

        {





            return View();



        }


        [HttpPost]

        public ActionResult Signup(string name, string email, string username, HttpPostedFileBase profile, string pass)

        {


            String command = "insert into sin_up values('" + name + "','" + email + "','" + username + "','" + profile.FileName + "','" + pass + "');";



            int d = database.InserUpdateDelete(command);


            if (d > 0)
            {


                profile.SaveAs(Server.MapPath("/Content/profile/") + profile.FileName);

                return Content("<script>alert('user successfully registered! please log in to continue'); location.href='/home/login';</script>");

            }


            else
            {
                profile.SaveAs(Server.MapPath("/Content/profile/") + profile.FileName);

                return Content("<script>alert('user registration failed'); location.href='/home/login';</script>");


            }




        }

        public ActionResult purchase_page(int? sr)
        {
            String command = "select * from add_game where sr='"+sr+"'";


            DataTable jt = database.SelectStatment(command);
            ViewBag.pur = jt;




            return View();



        }


        public ActionResult games()
             
        {


            String command = "select * from add_game";


            DataTable dt = database.SelectStatment(command);
            ViewBag.Data = dt;





            return View();



     

        }


        public ActionResult adminlogin()
        {

            return View();

        }
        [HttpPost]

        public ActionResult adminlogin(string mail,string pass)
        {
            string command = "select * from admin where adminid='" + mail + "'and password='" + pass + "'";


                    DataTable dt= database.SelectStatment(command);

            if (dt.Rows.Count > 0)
            {

                Session["admin"] = mail;

                return RedirectToAction("index", "admin");


            }

            else
           {

                return Content("<script>alert('bhag yaha se')</script>");
            
            
            }


         

        }


       
       

        public ActionResult feeds()
        {

            if (Session["User"] == null)
            {

                return Content("<script> alert('plz login first'); location.href='/home/login'</script>");



            }

            else
            {

                //string command = "select * from profile_sec ";

                //DataTable dt= database.SelectStatment(command);

                //ViewBag.feed= dt;


                string command = "select * from profile_sec ";

                DataTable dt = database.SelectStatment(command);

                ViewBag.feed = dt;


                string comm = "select * from profile_sec FULL OUTER JOIN sin_up ON profile_sec.us=sin_up.username where post_id ! = 0";

                DataTable jt = database.SelectStatment(comm);

                ViewBag.pro = jt;




                //string comm="select * from sinup where us" 

                return View();
            }
        }


    }


    class CheckSession : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session= filterContext.HttpContext.Session;

            if (session["admin"]==null) {

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            {

                {"Controller","Home"},
                {"Action","adminlogin" }


            });
            
            }

          
        }


       

    }

















    class Check : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["User"] == null)
            {

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            {

                {"Controller","Home"},
                {"Action","login" }


            });

            }


        }




    }



}