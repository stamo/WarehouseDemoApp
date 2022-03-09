using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Infrastructure.Data
{
    public class Deal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ContragentId { get; set; }

        [ForeignKey(nameof(ContragentId))]
        public Contragent Contragent { get; set; }

        public IList<DealSubject> DealSubjects { get; set; }

    }
}
