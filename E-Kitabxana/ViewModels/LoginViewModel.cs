﻿using E_Kitabxana.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Kitabxana.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        [MinLength(3,ErrorMessage = "İstifadəçi adı min 5 hərf olmalıdır")]
        
        public string Username {  get; set; }
        [Required(ErrorMessage = "Şifrə adı boş ola bilməz")]
         [MinLength(3,ErrorMessage = "İstifadəçi adı min 5 hərf olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}