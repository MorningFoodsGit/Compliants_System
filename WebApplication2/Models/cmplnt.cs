using MessagePack;
using System.ComponentModel.DataAnnotations;
using System;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel;

namespace WebApplication2.Models
{
    public class cmplnt_base
    {
        [Key]
        [Required]
        public int cmplnt_ID { get; set; }
        public string? cstmr_nme { get; set; }
        public string? cstmr_ref_rtlr { get; set; }
        public string? cstmr_ref_mf { get; set; }
        public string? rtlr { get; set; }
        public string? Site { get; set; }
        public string? prdct_ctgry { get; set; }
        public string? prdct_cde_rtlr { get; set; }
        public string? prdct_cde_mf { get; set; }
        public string? bbe_info { get; set; }
        public string? cmplnt_ctgry { get; set; }
        public string? cmplnt_src { get; set; }
        public string? cmplnt_desc { get; set; }
        public int? jlenne_cde { get; set; }
        public string? prdct_desc { get; set; }
        public string? Actn { get; set; }
        public DateTime? bbe_dte { get; set; }
        public DateTime? cmplnt_dte { get; set; }
        public DateTime? tdy_dte { get; set; }
    }
}
