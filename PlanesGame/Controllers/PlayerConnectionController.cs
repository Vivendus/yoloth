using PlanesGame.Models;
using PlanesGame.Views;

namespace PlanesGame.Controllers
{
    public class PlayerConnectionController
    {
        private readonly IPlayerConnectionView _view;

        public PlayerConnectionController(IPlayerConnectionView view, bool showConnectionInfo)
        {
            _view = view;
            _view.SetConnectionDataView(showConnectionInfo);
            _view.SetController(this);
        }

        public PlayerConnectionInfo PlayerConnectionInfo { get; set; }

        public void SetUpConnection()
        {
            PlayerConnectionInfo = new PlayerConnectionInfo
            {
                Name = _view.PlayerName,
                RemoteAddress = _view.PlayerIp
            };
        }
    }
}