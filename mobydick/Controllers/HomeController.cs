using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            {
                List<WordModel> lwords = new List<WordModel>();

                //Load the XML file in XDocument.

                XDocument doc = XDocument.Load(Server.MapPath("~/App_Data/mobydick.xml"));

                var selectedWord = from r in doc.Descendants("word")
                                  select r;

                //Loop through the selected Nodes.
                foreach (XElement node in selectedWord)
                {
                    //Fetch the Node values and assign it to Model.
                    lwords.Add(new WordModel
                    {
                        Wtext = node.Attribute("text").Value,
                        Wcount = node.Attribute("count").Value
                    });
                }
                return View(lwords);
            }
        }
    }
}