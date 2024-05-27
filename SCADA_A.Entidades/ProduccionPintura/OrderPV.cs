using System;
namespace SCADA_A.Entidades.ProduccionPintura
{
	public class OrderPV
	{
		public Guid OrderID { get; set; }
		public string OrderName { get; set; }
		public int LabelID { get; set; }
		public string Comment { get; set; }
	}
}

