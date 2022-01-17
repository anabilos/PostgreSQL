using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGU.Models;

namespace WebApiGU.Data
{
    public interface IRepository
    {
        //kupac
        List<GetAllKupce> AllKupac();
        CreateKupacResponse CreateKupac(CreateKupacRequest Kupac);
        UpdateKupacResponse UpdateKupac(UpdateKupacRequest Kupac);
        DeleteKupacResponse DeleteKupacById(int idKupac);
        GetKupacById GetKupac(int idKupac);

        //izlozba
        CreateIzlozbaResponse CreateIzlozba(CreateIzlozbaRequest Izlozba);
        List<GetAllIzlozbe> AllIzlozba();
        DeleteIzlozbaResponse DeleteIzlozbaById(int idIzložba);
        GetIzlozbaById GetIzlozba(int idIzložba);
        UpdateIzlozbaResponse UpdateIzlozba(UpdateIzlozbaRequest Izlozba);

        //umjetnik
        List<GetAllUmjetnike> AllUmjetnik();
        CreateUmjetnikResponse CreateUmjetnik(CreateUmjetnikRequest Umjetnik);
        UpdateUmjetnikResponse UpdateUmjetnik(UpdateUmjetnikRequest Umjetnik);
        DeleteUmjetnikResponse DeleteUmjetnikById(int idUmjetnik);
        GetUmjetnikById GetUmjetnik(int idUmjetnik);
        List<GetListuMjestaPoNazivu> AllMjesta();

        //tip_umjetnine
        List<GetAllTipove> AllTip();
        CreateTipResponse CreateTip(CreateTipRequest Tip);
        UpdateTipResponse UpdateTip(UpdateTipRequest Tip);
        DeleteTipResponse DeleteTipById(int idTip);
        GetTipById GetTip(int idTip);

        //umjetnina
        List<GetAllUmjetnine> AllUmjetnina();
        CreateUmjetninaResponse CreateUmjetnina(CreateUmjetninaRequest Umjetnina);
        UpdateUmjetninaResponse UpdateUmjetnina(UpdateUmjetninaRequest Umjetnina);
        DeleteUmjetninaResponse DeleteUmjetninaById(int idUmjetnina);
        GetUmjetninaById GetUmjetnina(int idUmjetnina);
        List<GetListuUmjetnikaPoNazivu> AllUmjetnika();
        List<GetListuTipovaPoNazivu> AllTipova();
    }
}
