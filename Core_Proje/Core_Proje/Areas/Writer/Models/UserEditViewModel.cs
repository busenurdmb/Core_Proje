using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen  Adınızı Girin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Lütfen Şifreyi Adını Girin")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi tekrar Girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen resim Url değeri Girin")]
         public string PictureUrl { get; set; }
        // IFormFile --> dosyanın wwwroot un içine kaydolması için gerekli
        //olan tür
        public IFormFile Picture { get; set; }
    }
}
