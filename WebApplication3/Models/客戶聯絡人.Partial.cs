namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebApplication3.Models.InputValidations;


    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public 客戶聯絡人Repository repo { get; set; }
        public 客戶聯絡人()
        {
            this.repo = RepositoryHelper.Get客戶聯絡人Repository();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (repo.EmailDuplicate(Id,客戶Id,Email))
            {
                yield return new ValidationResult("Email重複", new[] { "Email" });
            }

        }
    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }

        [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        //[RegularExpression(@"\d{4}-\d{6}")]
        [CellPhone]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
