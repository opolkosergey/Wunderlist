using System.IO;
using System.Web;
using System.Web.Mvc;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.WebUI.Mapper
{
    public class ProfileBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            var name = request.Form.Get("newUserName");
            var id = request.Form.Get("userId");
            HttpPostedFileBase image = request.Files.Get("image");
            string fileName = "";
            if (image != null)
            {
                var fullPath = UserContentPathResolver.SavePhoto(controllerContext, image);
                fileName = Path.GetFileName(fullPath);
            }
          
            return new UserProfileModel()
            {
                Id = int.Parse(id),
                Photo = fileName,
                Name = name
            };
        }
    }
}