using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestIntegracion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class XMLFile : ControllerBase
    {

        [HttpGet]
        public ActionResult GetText()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Technical Test - File 1.txt");
                var path = "methodResponse/params/param";

                var stringText = string.Empty;
                foreach (XmlNode item in xmlDoc.SelectNodes(path))
                {
                    if (string.IsNullOrEmpty(item.InnerText))
                        throw new Exception("The item String not contain Text");
                    else
                    {
                       stringText = item.InnerText;
                    }
                }

                return Ok(stringText);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
