﻿using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class DashboardSettings
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bölüm Adı önemli")]
        public string? DepartmentName { get; set; }
        public string? Description { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? IconePath { get; set; }

    }
}
