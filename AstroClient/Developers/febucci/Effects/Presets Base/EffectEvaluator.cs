namespace AstroClient.febucci.Effects.Presets_Base
{
    interface EffectEvaluator
    {
        void Initialize(int type);

        bool isEnabled { get; }
        float Evaluate(float time, int characterIndex);
        float GetDuration();
    }

}