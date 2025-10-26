using Core.Context;
using Core.Generator;
using Core.StageFactory;
using Core.Stages;
using Entry.EntryData;
using UI.Lists;

namespace Core.StateMachine.ConcretStages
{
    public class OrderStageSelection : IStage
    {
        private IStageController _controller;
        private IStageFactory _stageFactory;
        private OrderListView _orderListView;
        private OrdersGenerator _ordersGenerator;
        private OrdersGeneratorConfig _ordersConfig;
        private DeliveryContext _context;

        public OrderStageSelection(IStageController controller, StageDependencies stageDependencies)
        {
            _context = stageDependencies.DeliveryContex;
            _controller = controller;
            _stageFactory = _controller.StageFactory;

            _orderListView = stageDependencies.OrderListView;
            _ordersGenerator = new
                (stageDependencies.OrdersGeneratorConfig,
                stageDependencies.ItemsCategoryConfigs,
                _context.SelectedDistrict.DData.PricePerDistanceUnit);

            _ordersConfig = stageDependencies.OrdersGeneratorConfig;
        }

        public void Enter()
        {
            _orderListView.Init(_ordersGenerator.GenerateItemList(_ordersConfig.InitialCountItemGenerated));
            if (!_orderListView.gameObject.activeSelf)
                _orderListView.Show();

            _orderListView.OnOrderSelected += HandleSelectedOrder;
        }

        public void Exit()
        {
            _orderListView.OnOrderSelected -= HandleSelectedOrder;
            _orderListView.Hide();
            Dispose();
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
            _controller = null;
            _stageFactory = null;
            _orderListView = null;
        }

        private void HandleSelectedOrder(OrderGeneratedData data)
        {
            _controller.SetStage(_stageFactory.CreateExecutionStage(_controller));
        }
    }
}