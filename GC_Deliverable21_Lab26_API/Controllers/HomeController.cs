using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace GC_Deliverable21_Lab26_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PlayCards ()
        {
            /*** Deck handler ***/
            HttpWebRequest WReq = WebRequest.CreateHttp("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            WReq.UserAgent = ".NET Application API Testing for Lab 26";

            HttpWebResponse WResp = (HttpWebResponse)WReq.GetResponse();
            StreamReader reader = new StreamReader(WResp.GetResponseStream());
            string deck = reader.ReadToEnd();

            JObject cardsJSON = JObject.Parse(deck);
            string deckId = (string)cardsJSON["deck_id"];

            /*** Draw handler ***/
            WReq = WebRequest.CreateHttp($"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=5");
            WResp = (HttpWebResponse)WReq.GetResponse();
            reader = new StreamReader(WResp.GetResponseStream());
            string hand = reader.ReadToEnd();

            cardsJSON = JObject.Parse(hand);

            /*** Build the view ***/
            ViewBag.Hand = cardsJSON["cards"];

            /*** Send the view ***/
            return View();
        }
    }
}