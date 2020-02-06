using IOTProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace IOTProject.Controllers.APIs
{
    public class InformDefectController : ApiController
    {
        public void Get( string defectId)
        {
 

            using (IOTMOdel context = new IOTMOdel())
            {
                //  string query_1 = @"INSERT INTO [dbo].[Issues]([DefectID],[RequestTime],[ResponceTime],[status]) OUTPUT INSERTED.ID VALUES('" + defectId + "','"+ DateTime.Now + "','','"+false+ "')";
                //  string query_1 = @"Insert into Issues(DefectID, RequestTime, ResponceTime, status) Output Inserted.ID Values('" + defectId + "','" + DateTime.Now + "','','" + false + "')";
                //   Debug.WriteLine(query_1);
                Issues issues = new Issues();

                issues.status = true;
                issues.DefectID = defectId;
                issues.RequestTime = DateTime.Now;
                issues.ResponceTime = DateTime.Now;
                context.Issues.Add(issues);
                context.SaveChanges();// end of the save
                try
                {
                    context.SaveChanges();
                    var lineInfo = context.IPs.Where(x => x.RaspBerryID == 2).FirstOrDefault();
                    string responce= TakeAction(lineInfo.IPAddress, defectId, issues.ID);
                    int issue = Int32.Parse(responce);
                  
                    var issueEntity = context.Issues.SingleOrDefault(f => f.ID == issue);
                    issueEntity.status = true;
                    issueEntity.ResponceTime = DateTime.Now;
                    context.SaveChanges();

                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Error " + ex);
                }
            }
        }

        public string TakeAction(string ip, string defectId ,int Issueid)
        {
            string url = "http://" + ip + "/led.php?on=" + defectId + "&Id="+Issueid.ToString();

            string responseText;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //request.Accept = "application/xrds+xml";  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            return responseText;
        }



        ////Realtime update the status
         [System.Web.Http.Route("api/getData")]
        public String Get()
        {


            using (IOTMOdel context = new IOTMOdel())
            {

               
                List<Issues> jcList = context.Issues.Where(x => x.status ==true || x.status == false).ToList();
                string yourJson = Newtonsoft.Json.JsonConvert.SerializeObject(jcList);

               
                return yourJson;


            }
        }



    }
}
