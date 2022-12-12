using HotelManagement.Web.ViewModels.RoomModels;

namespace HotelManagement.Data.Services.RoomServices.Contracts
{
    public interface IRoomServices
    {
        /// <summary>
        ///     Gets RoomDetailsViewModel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;RoomDetailsViewModel&gt;</returns>
        public Task<RoomDetailsViewModel> GetRoomDetailsModelAsync(int id);

        /// <summary>
        /// Gets room RoomEditViewModel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;RoomEditViewModel&gt;</returns>
        public Task<RoomEditViewModel> GetRoomEditViewModelAsync(int id);

        /// <summary>
        /// Edits room with the RoomEditViewModel given
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Task&lt;int&gt;</returns>
        public Task<int> EditRoomWithEditViewModel(RoomEditViewModel model);

        /// <summary>
        /// Deletes room by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> DeleteRoomById(int id);

        /// <summary>
        /// Enables room by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> EnableRoomById(int id);

        /// <summary>
        /// Sets room status to out of service by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> RoomOutOfServiceByIdAsync(int id);

        /// <summary>
        /// Sets room status to in service by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> RoomInServiceByIdAsync(int id);

        /// <summary>
        /// Sets room status cleaned by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> IsCleanedAsync(int id);

        /// <summary>
        /// Sets room status dirty by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task&lt;bool&gt;</returns>
        public Task<bool> IsDirtyAsync(int id);
    }
}
