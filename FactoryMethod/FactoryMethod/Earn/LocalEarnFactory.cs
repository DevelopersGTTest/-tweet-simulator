namespace FactoryMethod.Earn
{
    public class LocalEarnFactory : EarnFactory
    {
        private decimal _percentage;

        public LocalEarnFactory(decimal percentage) { 
            _percentage = percentage;
        }

        public override IEarn GetEarn()
        {
            // this method will be called for each invocation
            return new LocalEarn(_percentage);
        }
    }
}
