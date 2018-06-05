using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class AutoActions
    {
        int boardId { get; set; }
        int triggerId { get; set; }
        int secondaryId { get; set; }
        int actionId { get; set; }
        string color { get; set; }
        int categoryId { get; set; }
        int assigneeId { get; set; }
    }
}
