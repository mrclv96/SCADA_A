using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.ProduccionPintura;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.ProduccionPintura
{
    public class SkidProtocolMap : IEntityTypeConfiguration<SkidProtocol>
    {
        public void Configure(EntityTypeBuilder<SkidProtocol> builder)
        {
            builder.ToTable("SkidProtocol")
                .HasKey(p => p.ProtID);
        }
    }
}
