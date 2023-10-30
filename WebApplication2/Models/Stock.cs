using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using System;
using System.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Stock
    {
		[Key]
		[Required]
		public string Stkid { get; set; }
        public string? StkDesc { get; set; }
		[NotMapped]
		public string? StkEAN { get; set; }
		[NotMapped]
		public string? StkUEAN { get; set; }
		[NotMapped]
		public string? StkExDesc { get; set; }
		[NotMapped]
		public string? StkType { get; set; }
		[NotMapped]
		public Decimal? StkLife { get; set; }
		[NotMapped]
		public Decimal? StkUC { get; set; }
		[NotMapped]
		public Decimal? StkCP { get; set; }
		[NotMapped]
		public Decimal? StkCWgt { get; set; }
		[NotMapped]
		public Decimal? StkCVol { get; set; }
		[NotMapped]
		public Decimal? StkPWgt { get; set; }
		[NotMapped]
		public string? StkStat { get; set; }
		[NotMapped]
		public DateTime? StkLRec { get; set; }
		[NotMapped]
		public DateTime? StkLIss { get; set; }
		[NotMapped]
		public Decimal? StkCIn { get; set; }
		[NotMapped]
		public Decimal? StkCFree { get; set; }
		[NotMapped]
		public string? StkCommCde { get; set; }
		[NotMapped]
		public string? StkOrigin { get; set; }
		[NotMapped]
		public string? StkLabel { get; set; }
		[NotMapped]
		public int? StkCopies { get; set; }
		[NotMapped]
		public int? StkHasBatno { get; set; }
		[NotMapped]
		public Decimal? StkXMod { get; set; }
		[NotMapped]
		public string? StkPbID { get; set; }
		[NotMapped]
		public string? StkPfID { get; set; }
		[NotMapped]
		public string? StkTyID { get; set; }
		[NotMapped]
		public Decimal? StkTWgt { get; set; }
		[NotMapped]
		public string? StkMatCode { get; set; }
		[NotMapped]
		public string? StkDefWhid { get; set; }
		[NotMapped]
		public Decimal? StkCostPrice { get; set; }
		[NotMapped]
		public Decimal? StkSellingPrice { get; set; }
		[NotMapped]
		public Decimal? StkLastCost { get; set; }
		[NotMapped]
		public Decimal? StkAverageCost { get; set; }
		[NotMapped]
		public int? StkMCat1 { get; set; }
		[NotMapped]
		public int? StkMCat2 { get; set; }
		[NotMapped]
		public string? StkWUnit { get; set; }
		[NotMapped]
		public string? StkMemo { get; set; }
		[NotMapped]
		public string? StkVatCode { get; set; }
		[NotMapped]
		public string? StkAnalysisCode { get; set; }
		[NotMapped]
		public string? StkShelfLabel { get; set; }
		[NotMapped]
		public int? MinimumStock { get; set; }
		[NotMapped]
		public int? ReOrderLevel { get; set; }
		[NotMapped]
		public int? ReOrderAmount { get; set; }
		[NotMapped]
		public int? LeadTime { get; set; }
		[NotMapped]
		public int? AverageLeadTime { get; set; }
		[NotMapped]
		public string? StkCoID { get; set; }
		[NotMapped]
		public string? SalesCode { get; set; }
		[NotMapped]
		public string? PurchaseCode { get; set; }
		[NotMapped]
		public int? StkShortCode { get; set; }
		[NotMapped]
		public string? StkInternalProductCode { get; set; }
		[NotMapped]
		public string? StkAltRef { get; set; }
		[NotMapped]
		public Decimal? StkSellBy { get; set; }
		[NotMapped]
		public Decimal? StkUnitsPerPallet { get; set; }
		[NotMapped]
		public Decimal? StkUnitWeight { get; set; }
		[NotMapped]
		public string? StkMdID { get; set; }
		[NotMapped]
		public string? StkThickness { get; set; }
		[NotMapped]
		public string? StkPallTypeID { get; set; }
		[NotMapped]
		public string? StkSpInstructions { get; set; }
		[NotMapped]
		public string? StkMatID { get; set; }
		[NotMapped]
		public int? StkLblTempNo { get; set; }
		[NotMapped]
		public string? StkRoID { get; set; }
		[NotMapped]
		public string? StkPsID { get; set; }
		[NotMapped]
		public Decimal? StkPriPaperWeight { get; set; }
		[NotMapped]
		public Decimal? StkPriGlassWeight { get; set; }
		[NotMapped]
		public Decimal? StkPriAluminiumWeight { get; set; }
		[NotMapped]
		public float? StkPriSteelWeight { get; set; }
		[NotMapped]
        public float? StkPriPlasticWeight { get; set; }
		[NotMapped]
        public float? StkPriWoodWeight { get; set; }
		[NotMapped]
        public float? StkPriOtherWeight { get; set; }
		[NotMapped]
        public float? StkSecPaperWeight { get; set; }
		[NotMapped]
        public float? StkSecGlassWeight { get; set; }
		[NotMapped]
        public float? StkSecAluminiumWeight { get; set; }
		[NotMapped]
        public float? StkSecSteelWeight { get; set; }
		[NotMapped]
        public float? StkSecPlasticWeight { get; set; }
		[NotMapped]
		public float? StkSecWoodWeight { get; set; }
		[NotMapped]
        public float? StkSecOtherWeight { get; set; }
		[NotMapped]
        public float? StkTerPaperWeight { get; set; }
		[NotMapped]
        public float? StkTerGlassWeight { get; set; }
		[NotMapped]
        public float? StkTerAluminiumWeight { get; set; }
		[NotMapped]
        public float? StkTerSteelWeight { get; set; }
		[NotMapped]
        public float? StkTerPlasticWeight { get; set; }
		[NotMapped]
        public float? StkTerWoodWeight { get; set; }
		[NotMapped]
        public float? StkTerOtherWeight { get; set; }
		[NotMapped]
        public float? ProfileCode { get; set; }
		[NotMapped]
        public float? RetailPrice { get; set; }
		[NotMapped]
        public float? DepositAmount { get; set; }
		[NotMapped]
        public float? DepositPercentage { get; set; }
		[NotMapped]
        public bool? ReturnRequired { get; set; }
		[NotMapped]
        public bool? StkUpdated { get; set; }
		[NotMapped]
        public DateTime? StkUpDateTime { get; set; }
		[NotMapped]
        public string? StkUpUser { get; set; }
		[NotMapped]
        public string? StkReturnID { get; set; }
		[NotMapped]
        public float? StkDefaultContainerSize { get; set; }
		[NotMapped]
        public string? StkGoldItemCode { get; set; }
		[NotMapped]
        public bool? StkGoldUpdated { get; set; }
		[NotMapped]
        public string? StkGoldType { get; set; }
		[NotMapped]
        public float? StkGoldHGCA { get; set; }
		[NotMapped]
        public string? StkGoldQualSysItem { get; set; }
		[NotMapped]
        public string? StkGoldSubGroupCode { get; set; }
		[NotMapped]
        public DateTime? StkGoldUpdateTime { get; set; }
		[NotMapped]
        public int? StkBookinQuestions { get; set; }
		[NotMapped]
        public string? StkGoldShortName { get; set; }
		[NotMapped]
        public int? StkCertGroupID { get; set; }
		[NotMapped]
        public string? StkLifeSpanType { get; set; }
		[NotMapped]
        public int? StkStockGroupID { get; set; }
		[NotMapped]
        public float? StkNetCWgt { get; set; }
		[NotMapped]
        public float? StkTareWgt { get; set; }
		[NotMapped]
        public bool? StkPrintItemLabel { get; set; }
		[NotMapped]
        public int? StkItemLabel { get; set; }
		[NotMapped]
        public int? StkCaseLabel { get; set; }
		[NotMapped]
        public string? StkBatchComponent { get; set; }
		[NotMapped]
        public string? StkWMSDesc { get; set; }
		[NotMapped]
        public int? StkBrand { get; set; }
		[NotMapped]
        public string? StkLabelInfo1 { get; set; }
		[NotMapped]
        public string? StkLabelInfo2 { get; set; }
		[NotMapped]
        public string? StkExternalLabelFile { get; set; }
		[NotMapped]
        public bool? StkExternalFill { get; set; }
		[NotMapped]
        public string? StkDefaultProductionSiteId { get; set; }
		[NotMapped]
        public string? StkIngredientGroup { get; set; }
    }
}
