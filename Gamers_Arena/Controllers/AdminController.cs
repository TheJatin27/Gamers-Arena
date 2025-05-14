using Gamers_Arena.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Gamers_Arena.Controllers
{

    [CheckSession]
    public class AdminController : Controller
    {
        // GET: Admin
        db database = new db();

      
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Game()
        {



            String command = "select * from add_game";


            DataTable dt = database.SelectStatment(command);
            ViewBag.Data = dt;





            return View();



        }




        [HttpPost]
        public ActionResult Game(string name_game, HttpPostedFileBase vid, HttpPostedFileBase icon, string description1, string Description2, string Description3,HttpPostedFileBase landscape1, HttpPostedFileBase landscape2, HttpPostedFileBase landscape3,string price,string sale,string dev,string date,string chota,string head1, string hed2,string head3)
            {
         

            string command = "insert into add_game(name,video,icon,des1,des2,des3,img1,img2,img3,price,sale,developer,release,short_d,h1,h2,h3) values('"+name_game+"','"+vid.FileName+"','"+icon.FileName+ "','"+description1+"','"+Description2+"','"+Description3+"','"+landscape1.FileName+"','"+landscape2.FileName+"','"+landscape3.FileName+"','"+price+"','"+sale+"','"+dev+"','"+date+"', '"+chota+"','"+head1+"','"+hed2+"','"+head3+"');"; 

          int a =database.InserUpdateDelete(command);









            //return View();

            if (a > 0)
            {



                vid.SaveAs(Server.MapPath("/Content/GameVide/") + vid.FileName);

                icon.SaveAs(Server.MapPath("/Content/gameIcon/") + icon.FileName);



                landscape1.SaveAs(Server.MapPath("/Content/GameImage/") + landscape1.FileName);



                landscape2.SaveAs(Server.MapPath("/Content/GameImage/") + landscape2.FileName);


                landscape3.SaveAs(Server.MapPath("/Content/GameImage/") + landscape3.FileName);

                return Content("<script>alert('ho gaya'); location.href='/admin/game';</script>");

            }


            else
            {

                vid.SaveAs(Server.MapPath("/Content/GameVide/") + vid.FileName);

                icon.SaveAs(Server.MapPath("/Content/gameIcon/") + icon.FileName);



                landscape1.SaveAs(Server.MapPath("/Content/GameImage/") + landscape1.FileName);



                landscape2.SaveAs(Server.MapPath("/Content/GameImage/") + landscape2.FileName);


                landscape3.SaveAs(Server.MapPath("/Content/GameImage/") + landscape3.FileName);

                return Content("<script>alert('ho gaya'); location.href='/admin/game';</script>");


            }





            return View();
        }




        public ActionResult add_user()
        {



            String command = "select * from sin_up";


            DataTable dt = database.SelectStatment(command);
            ViewBag.Data = dt;


            return View();
        }
    

        [HttpPost] 

        public ActionResult add_user(string name, string email, string username, HttpPostedFileBase profile, string pass)
        {
            String command = "insert into sin_up values('" + name + "','" + email + "','" + username + "','" + profile.FileName + "','" + pass + "');";
           int d= database.InserUpdateDelete(command);
         



            if (d > 0)
            {

                profile.SaveAs(Server.MapPath("/Content/profile/") + profile.FileName);


                return Content("<script>alert('ho gaya'); location.href='/admin/add_user';</script>");

            }


            else
            {


                profile.SaveAs(Server.MapPath("/Content/profile/")+profile.FileName);

                return Content("<script>alert('nahi hua'); location.href='/admin/add_user';</script>");


            }


        }


       public ActionResult tournment()
        {


            String command = "select sr,name from add_game";

           DataTable dt= database.SelectStatment(command);

            ViewBag.tour=dt;


            String comm = "select * from tournment";

            DataTable dy = database.SelectStatment(comm);

            ViewBag.tour = dy;




            return View();

        }


        [HttpPost]

        public ActionResult tournment(string name, string Con,string game,HttpPostedFileBase image)
        {

            string Command = "insert into tournment values('"+name+"','"+Con+"','"+game+"','"+image.FileName+"')";

          int d=  database.InserUpdateDelete(Command);



            if (d > 0)
            {
                image.SaveAs(Server.MapPath("/Content/tournmentImage/") + image.FileName);

                return Content("<script>alert('ho gaya'); location.href='/admin/tournment';</script>");

            }


            else
            {


                image.SaveAs(Server.MapPath("/Content/tournmentImage/") + image.FileName);

                return Content("<script>alert('nahi hua'); location.href='/admin/tournment';</script>");


            }




        }


        public ActionResult logout()
        {

            Session.Remove("admin");
            return RedirectToAction("index","home");


        }












    }




    }
