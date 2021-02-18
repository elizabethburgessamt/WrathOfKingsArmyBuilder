using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WOKArmyBuilder.Models;

namespace WOKArmyBuilder.Repositories
{
    public interface IArmyListRepository
    {
        event EventHandler<ArmyList> OnListAdded;
        event EventHandler<ArmyList> OnListUpdated;
        event EventHandler<ArmyList> OnListDeleted;

        Task<List<ArmyList>> GetArmyLists();
        Task NewList(ArmyList list);
        Task UpdateList(ArmyList list);
        Task DeleteList(ArmyList list);

        Task<List<Unit>> GetUnits();
    }
}
