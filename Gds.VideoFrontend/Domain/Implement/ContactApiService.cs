using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Gds.VideoFrontend.Models;
using Newtonsoft.Json;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class ContactApiService : IContactApiService
    {

        public ContactViewModel LoginAction(string userName, string password)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.bibook.vn/api/oauth");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var postData = new StringBuilder();
            postData.AppendFormat("user={0}", userName);
            postData.AppendFormat("&password={0}", password);
            postData.AppendFormat("&device=xvideobibook");
            postData.AppendFormat("&system=video_bibook");
            var bytes = Encoding.UTF8.GetBytes(postData.ToString());
            request.ContentLength = bytes.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream == null) return new ContactViewModel();

            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            var dataResult = CombiJsonToModel(result);
            stream.Dispose();
            reader.Dispose();
            return dataResult;
        }

        public ContactViewModel LoginAuthentication(IdentityUserModel model)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.bibook.vn/api/googlelogin");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var postData = new StringBuilder();
            switch (model.Type)
            {
                case "GOOGLE":
                    postData.AppendFormat("google_id={0}", model.Id);
                    postData.AppendFormat("&google_token={0}", model.Token);
                    break;
                case "FACEBOOK":
                    postData.AppendFormat("facebook_id={0}", model.Id);
                    postData.AppendFormat("&facebook_token={0}", model.Token);
                    break;
            }
            postData.AppendFormat("&device=xvideobibook");
            postData.AppendFormat("&system=video_bibook");
            postData.AppendFormat("&email={0}", model.Email);
            postData.AppendFormat("&name={0}", model.Name);
            var bytes = Encoding.UTF8.GetBytes(postData.ToString());
            request.ContentLength = bytes.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream == null) return new ContactViewModel();

            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            var dataResult = CombiJsonToModel(result);
            stream.Dispose();
            reader.Dispose();
            return dataResult;
        }

        private ContactViewModel CombiJsonToModel(string result)
        {
            var model = new ContactViewModel();
            var jsonObj = JsonConvert.DeserializeObject<JsonUserModel>(result);
            model.SecurityCode = jsonObj.data.code;
            model.TokenUser = jsonObj.data.token;
            var user = jsonObj.data.user.FirstOrDefault();
            if (user == null) return model;

            model.ContactId = !string.IsNullOrEmpty(user.user_id) ? Convert.ToInt32(user.user_id) : 0;
            model.ContactName = user.user_name;
            model.ContactFullName = user.full_name;
            model.ContactEmail = user.email;
            model.ContactImage = user.user_image;
            model.ContactGender = user.gender;
            model.ContactGold = !string.IsNullOrEmpty(user.gold) ? Convert.ToDecimal(user.gold) : 0;
            model.ContactBirthday = user.birthday;

            return model;
        }
    }

    public class JsonUserModel
    {
        public string code { get; set; }

        public string message { get; set; }

        public DataModel data { get; set; }
    }

    public class DataModel
    {
        public string code { get; set; }
        public string token { get; set; }
        public List<UserModel> user { get; set; } 
    }

    public class UserModel
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string user_image { get; set; }
        public string gender { get; set; }
        public string gender_text { get; set; }
        public string gold { get; set; }
        public string birthday { get; set; }
    }
}