using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Mapper
{
    public static class ApplicationFolders
    {
        public static string UserContent = "UserContent";
        public static string UserPhotoPath = Path.Combine(UserContent, "Photos");
    }
    public class UserContentPathResolver
    {
        public static string Resolve(ControllerContext controllerContext, string folder)
        {
            var serverPath = controllerContext.HttpContext.Server.MapPath("~/");
            var path = Path.Combine(serverPath, folder);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static string SavePhoto(ControllerContext controllerContext, HttpPostedFileBase image)
        {
            var photosPath = UserContentPathResolver.Resolve(controllerContext, ApplicationFolders.UserPhotoPath);
            string fullPath = null;
            while (File.Exists(fullPath = Path.Combine(photosPath, Path.GetRandomFileName()))); //loop while getting unique file name
            fullPath = fullPath + "." + Path.GetExtension(image.FileName);
            image.SaveAs(fullPath);

            return fullPath;
        }
    }
}