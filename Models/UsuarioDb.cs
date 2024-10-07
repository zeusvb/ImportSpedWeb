using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;

namespace ImportSpedWeb.Models
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public Int16 usuario_id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

    //    usuario_id integer NOT NULL DEFAULT nextval('usuario_usuario_id_seq'::regclass),
    //nome character varying(100) COLLATE pg_catalog."default" NOT NULL,
    //email character varying(150) COLLATE pg_catalog."default",
    //status smallint,
    //dt_cad date NOT NULL,
    //dt_alt date NOT NULL,
    //senha character varying(30) COLLATE pg_catalog."default" NOT NULL,
    }
}
