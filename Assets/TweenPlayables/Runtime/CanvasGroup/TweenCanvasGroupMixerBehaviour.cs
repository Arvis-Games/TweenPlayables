using UnityEngine;

namespace AnnulusGames.TweenPlayables
{
    public class TweenCanvasGroupMixerBehaviour : TweenAnimationMixerBehaviour<CanvasGroup, TweenCanvasGroupBehaviour>
    {
        private FloatValueMixer alphaMixer = new FloatValueMixer();

        public override void Blend(TweenCanvasGroupBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.alpha.active)
            {
                alphaMixer.Blend(behaviour.alpha.Evaluate(progress), weight);
            }
        }

        public override void Apply(CanvasGroup binding)
        {
            if (alphaMixer.ValueCount > 0)
            {
                binding.alpha = alphaMixer.Value;
            }

            alphaMixer.Clear();
        }
    }

}