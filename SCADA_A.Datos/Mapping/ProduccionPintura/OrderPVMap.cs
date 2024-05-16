using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.ProduccionPintura;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.ProduccionPintura
{
    public class OrderPVMap : IEntityTypeConfiguration<OrderPV>
    {
        public void Configure(EntityTypeBuilder<OrderPV> builder)
        {
            builder.ToTable("PL_OrderPV")
                .HasKey(p => p.OrderID);
        }
    }
}
