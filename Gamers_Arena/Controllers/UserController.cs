using Gamers_Arena.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamers_Arena.Controllers
{
    public class UserController : Controller
    {

        db database = new db();
        // GET: User
        public ActionResult Index()
        {



            String command = "select top 9 * from add_game order by sr desc";


            DataTable dt = database.SelectStatment(command);
            ViewBag.ga = dt;
              

            return View();

           
        }

        public ActionResult feeds()
        {

            //string command = "select * from profile_sec ";

            //DataTable dt = database.SelectStatment(command);
                
            //ViewBag.feed = dt;


            string comm = "select * from profile_sec FULL OUTER JOIN sin_up ON profile_sec.us=sin_up.username where post_id ! = 0 order by post_id desc ";

            DataTable jt = database.SelectStatment(comm);

            ViewBag.pro = jt;


            return View();
        }


        public ActionResult profile() {

           

            if (Session["User"] != null)
            {
           
                string command = "select * from profile_sec where us='" + Session["User"] +"'";

                DataTable dt = database.SelectStatment(command);

                ViewBag.profile = dt;

                string comman = "select * from edit where gamer='" + Session["User"] + "'";

                DataTable d = database.SelectStatment(comman);
                ViewBag.edit = d;



                string comm = "select * from sin_up where username='" + Session["User"] +"'";

                DataTable jt = database.SelectStatment(comm);

                ViewBag.user = jt;

                return View();


                //return RedirectToAction("profile");

            }

            else
            {
                return View();
            }

        }

        public ActionResult purchase_page()
        {

            return View();

        }


        public ActionResult games()
        {


            String command = "select * from add_game";


            DataTable dt = database.SelectStatment(command);
            ViewBag.Data = dt;






            return View();

        }
        public ActionResult logout()
        {

            Session.Remove("user");
            return RedirectToAction("index", "home");


        }


        public ActionResult edit_profile()
        {

            string comman = "select * from edit where gamer='" + Session["User"] + "'";

            DataTable d = database.SelectStatment(comman);
            ViewBag.edit = d;


            return View();

        }


        [HttpPost]
        public ActionResult edit_profile(string name, string rank,string g_name,string g_id,string Season)
        {

            string comma = "select * from edit where gamer='" + Session["User"] + "'";

            DataTable d = database.SelectStatment(comma);
            ViewBag.edit = d;

            if (ViewBag.edit.Rows.Count > 0) {
                string command = "UPDATE edit SET  gamer= '" + Session["User"] + "', game= '" + g_name + "', g_id='" + g_id + "',rank='" + rank + "', season='" + Season + "' WHERE gamer = '" + Session["User"] + "';";
                int a = database.InserUpdateDelete(command);


                if (a > 0)
                {
                    return Content("<script>alert('hua'); location.href='/user/profile';</script>");


                }
                else
                {
                    return Content("<script>alert('ni hua'); location.href='/user/profile';</script>");

                }

             

            }

            else
            {


                string comman = "insert into edit values('" + Session["User"] + "','" + g_name + "','" + g_id + "','" + rank + "','" + Season + "')";
                int a = database.InserUpdateDelete(comman);


                if (a > 0)
                {
                    return Content("<script>alert('hua'); location.href='/user/profile';</script>");


                }
                else
                {
                    return Content("<script>alert('ni hua'); location.href='/user/profile';</script>");

                }

            }
            
         

        }


        public ActionResult post()
        {

            string command = "select * from add_game";

           DataTable jt=  database.SelectStatment(command);

            ViewBag.Data = jt;



            return View();

        }

        [HttpPost]
        public ActionResult post(HttpPostedFileBase image_post,string name_post, string description,string game,string user)
        {


            if (Session["User"] != null)
            {

                String command = "insert into profile_sec values('" + image_post.FileName + "','" + name_post + "','" + description + "','" + game + "','"+ user+ "')";

                database.InserUpdateDelete(command);

                image_post.SaveAs(Server.MapPath("/Content/post/") + image_post.FileName);

                return RedirectToAction("post");
            }
            else
            {
                return Content("<script>alert.('ni hua')</script>");
            }

        }



        }
}