using HotelManagement.Web.ViewModels.RoomModels;

namespace HotelManagement.Data.Services.RoomServices.Contracts
{
    public interface IRoomServices
    {
        public Task<RoomDetailsViewModel> GetRoomDetailsModelAsync(int id);

        public Task<RoomEditViewModel> GetRoomEditViewModelAsync(int id);

        public Task<int> EditRoomWithRegisterViewModel(RoomEditViewModel model);

        public Task<bool> DeleteRoomById(int id);

        public Task<bool> EnableRoomById(int id);

        public Task<bool> RoomOutOfServiceByIdAsync(int id);

        public Task<bool> RoomInServiceByIdAsync(int id);

        public Task<bool> IsCleanedAsync(int id);

        public Task<bool> IsDirtyAsync(int id);
    }
}
