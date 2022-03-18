using AbstractFactory;

namespace PulpitSystem
{
    public class PulpitFactory : AbstractFactory<PulpitController>
    {
        public override PulpitController GetNewInstance()
        {
            return base.GetNewInstance();
        }
    }
}