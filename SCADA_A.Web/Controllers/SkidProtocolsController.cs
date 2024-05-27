using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Produccion;
using SCADA_A.Entidades.ProduccionPintura;
using SCADA_A.Web.Models.ProduccionPintura.SkidProtocol;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkidProtocolsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public SkidProtocolsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/SkidProtocols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkidProtocol>>> GetSkidProtocols()
        {
            return await _context.SkidProtocols.ToListAsync();
        }

        // GET: api/Skidprotocols/GetLastSkids
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<SkidViewModel>>> GetLastSkids()
        {

            var LabelIDList = await _context.SkidProtocols
                .OrderByDescending(s => s.DateAndTimeIN)
                .Where(s => s.Position == 1)
                .Select(s => s.LabelID)
                .Take(200)
                .ToListAsync();


            var LabelIDSkidProtocolsList = await _context.SkidProtocols
                .OrderByDescending(s => s.DateAndTimeIN)
                .Where(s => LabelIDList.Contains(s.LabelID))
                .ToListAsync();

            var LabelIDLastSkidProtocolList = LabelIDSkidProtocolsList
                .GroupBy(s => s.LabelID)
                .Select(g => g.FirstOrDefault())
                .ToList();

            var SkidList = (from skid in LabelIDLastSkidProtocolList
                            join order in _context.OrderPVs
                            on skid.OrderID equals order.OrderID
                            select new SkidViewModel
                            {
                                LabelID = skid.LabelID,
                                Position = skid.Position,
                                OrderName = skid.OrderName,
                                Skid_Number = skid.Skid_Number,
                                TypeLab = skid.TypeLab,
                                ColorLab = skid.ColorLab,
                                PrimerLab = skid.PrimerLab,
                                ClearLab = skid.ClearLab,
                                VariantNo = skid.VariantNo,
                                PitchVar = skid.PitchVar,
                                QTY1 = skid.QTY1,
                                QTY2 = skid.QTY2,
                                PartSide1 = skid.PartSide1,
                                PartSide2 = skid.PartSide2,
                                CO2 = skid.CO2,
                                Flaming = skid.Flaming,
                                Basecoat = skid.Basecoat,
                                DateAndTimeIN = skid.DateAndTimeIN,
                                Comment = order.Comment
                            });

            return Ok( SkidList );
        }

        // GET: api/Skidprotocols/GetSkidsFromDate/{date: format'yyyy-MM-dd'}
        [HttpGet("[action]/{date}")]
        public async Task<ActionResult<IEnumerable<SkidViewModel>>> GetSkidsFromDate(string date)
        {
            DateTime dateParsed;
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateParsed))
            {
                return BadRequest("Mal formato de fecha. La fecha debe tener el formato yyyy-MM-dd");
            }

            var LabelIDsFromDateList = await _context.SkidProtocols
                .Where(e => e.DateAndTimeIN.Date == dateParsed.Date && e.Position == 1)
                .Select(e => e.LabelID)
                .ToListAsync();

            if (LabelIDsFromDateList == null || LabelIDsFromDateList.Count == 0)
            {
                return NotFound("No se encontraron registros de esta fecha");
            }

            var SkidProtocolsFromDateList = await _context.SkidProtocols
                .OrderByDescending(s => s.DateAndTimeIN)
                .Where(e => LabelIDsFromDateList.Contains(e.LabelID))
                .ToListAsync();

            var LabelIDLastSkidProtocolList = SkidProtocolsFromDateList
                .GroupBy(s => s.LabelID)
                .Select(g => g.FirstOrDefault())
                .ToList();

            var SkidList = (from skid in LabelIDLastSkidProtocolList
                            join order in _context.OrderPVs
                            on skid.OrderID equals order.OrderID
                            select new SkidViewModel
                            {
                                LabelID = skid.LabelID,
                                Position = skid.Position,
                                OrderName = skid.OrderName,
                                Skid_Number = skid.Skid_Number,
                                TypeLab = skid.TypeLab,
                                ColorLab = skid.ColorLab,
                                PrimerLab = skid.PrimerLab,
                                ClearLab = skid.ClearLab,
                                VariantNo = skid.VariantNo,
                                PitchVar = skid.PitchVar,
                                QTY1 = skid.QTY1,
                                QTY2 = skid.QTY2,
                                PartSide1 = skid.PartSide1,
                                PartSide2 = skid.PartSide2,
                                CO2 = skid.CO2,
                                Flaming = skid.Flaming,
                                Basecoat = skid.Basecoat,
                                DateAndTimeIN = skid.DateAndTimeIN,
                                Comment = order.Comment
                            });

            return Ok( SkidList );
        }

        // GET: api/Skidprotocols/GetSkidByLabelID/{LabelID}
        [HttpGet("[action]/{labelID}")]
        public async Task<ActionResult<IEnumerable<SkidViewModel>>> GetSkidByLabelID(int labelID)
        {
            var SkidList = await (from skid in _context.SkidProtocols
                            join order in _context.OrderPVs
                            on skid.OrderID equals order.OrderID
                            where skid.LabelID == labelID
                            orderby skid.DateAndTimeIN descending
                            select new SkidViewModel
                            {
                                LabelID = skid.LabelID,
                                Position = skid.Position,
                                OrderName = skid.OrderName,
                                Skid_Number = skid.Skid_Number,
                                TypeLab = skid.TypeLab,
                                ColorLab = skid.ColorLab,
                                PrimerLab = skid.PrimerLab,
                                ClearLab = skid.ClearLab,
                                VariantNo = skid.VariantNo,
                                PitchVar = skid.PitchVar,
                                QTY1 = skid.QTY1,
                                QTY2 = skid.QTY2,
                                PartSide1 = skid.PartSide1,
                                PartSide2 = skid.PartSide2,
                                CO2 = skid.CO2,
                                Flaming = skid.Flaming,
                                Basecoat = skid.Basecoat,
                                DateAndTimeIN = skid.DateAndTimeIN,
                                Comment = order.Comment
                            })
                            .Take(1)
                            .ToListAsync();

            return Ok( SkidList );
        }

        // GET: api/Skidprotocols/GetSkidDetails/{LabelID}
        [HttpGet("[action]/{labelID}")]
        public async Task<ActionResult<IEnumerable<SkidDetailsViewModel>>> GetSkidDetails(int labelID)
        {
            try
            {
                var SkidDetails = await _context.SkidProtocols
                .Where(e => e.LabelID == labelID)
                .OrderBy(e => e.DateAndTimeIN)
                .Select(sd => new SkidDetailsViewModel
                {
                    DateAndTimeIN = sd.DateAndTimeIN,
                    Position = sd.Position,
                    LabelID = sd.LabelID,
                    TypeLab = sd.TypeLab,
                    PartSide1 = sd.PartSide1,
                    PartSide2 = sd.PartSide2,
                    BypassOnlChgCO2FL = sd.BypassOnlChgCO2FL,
                    BypassOnlChgPR = sd.BypassOnlChgPR,
                    BypassOnlChgBC = sd.BypassOnlChgBC,
                    BypassOnlChgCC = sd.BypassOnlChgCC,
                    FlagR1 = sd.FlagR1,
                    FlagR2 = sd.FlagR2,
                    FlagR3 = sd.FlagR3,
                    FlagR4 = sd.FlagR4,
                    FlagR5 = sd.FlagR5,
                    FlagR6 = sd.FlagR6,
                    ResinR1 = sd.ResinR1,
                    ResinR2 = sd.ResinR2,
                    ResinR3 = sd.ResinR3,
                    ResinR4 = sd.ResinR4,
                    ResinR5 = sd.ResinR5,
                    ResinR6 = sd.ResinR6,
                    HardenerR1 = sd.HardenerR1,
                    HardenerR2 = sd.HardenerR2,
                    HardenerR3 = sd.HardenerR3,
                    HardenerR4 = sd.HardenerR4,
                    Cleaning_R1 = sd.Cleaning_R1,
                    Cleaning_R2 = sd.Cleaning_R2,
                    Cleaning_R3 = sd.Cleaning_R3,
                    Cleaning_R4 = sd.Cleaning_R4,
                    Cleaning_R5 = sd.Cleaning_R5,
                    Cleaning_R6 = sd.Cleaning_R6,
                    ColorChg_R1 = sd.ColorChg_R1,
                    ColorChg_R2 = sd.ColorChg_R2,
                    ColorChg_R3 = sd.ColorChg_R3,
                    ColorChg_R4 = sd.ColorChg_R4,
                    ColorChg_R5 = sd.ColorChg_R5,
                    ColorChg_R6 = sd.ColorChg_R6,
                    CO2_R1 = sd.CO2_R1,
                    CO2_R2 = sd.CO2_R2,
                    TempBooth = sd.TempBooth,
                    HumBoothCC = sd.HumBoothCC
                })
                .ToListAsync();

                if (SkidDetails == null || SkidDetails.Count == 0)
                {
                    return NotFound("No existen registros con el LabelID");
                }

                return Ok(SkidDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al acceder a la base de datos", details = ex.Message });
            }

        }
    }
}
