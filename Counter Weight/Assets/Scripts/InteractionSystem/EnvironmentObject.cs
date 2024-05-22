using System.Reflection;
using UnityEngine;
using CounterWeight.Characters;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;

namespace CounterWeight.InteractionSystem
{
    public enum EnvrionmentObjectArgs {
        Character
    }

    public class EnvironmentObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Interaction[] interactions;
        [SerializeField] private GameEvent showSkillProgress;

        protected StringVariable speaker;
        protected StringVariable message;
        protected string inspectReponse;

        private SpriteRenderer sr;

        private void Awake()
        {
            sr = transform.Find("Prompt").GetComponent<SpriteRenderer>();
            speaker = Resources.Load<StringVariable>("Speaker");
            message = Resources.Load<StringVariable>("Message");
        }

        public Interaction[] GetInteractions()
        {
            return interactions;
        }
        
        public void Interact(Interaction interaction, object[] args)
        {
            string functionName = interaction.interactionName.Value;
            MethodInfo methodInfo = this.GetType().GetMethod(functionName);
            if (methodInfo != null)
            {
                speaker.Value = this.name;
                Character character = (Character)args[(int)EnvrionmentObjectArgs.Character];

                Skill interactionSkill = interaction.skillCheck;                
                if (interactionSkill != null)
                {
                    // If character doesn't have the skill, then automatic fail
                    int characterSkill = character.GetSkill(interactionSkill) != null ? character.GetSkill(interactionSkill).SkillLevel : -1;
                    if (characterSkill <= interactionSkill.SkillLevel)
                    {
                        // I should let the item present the message via callback
                        message.Value = interactionSkill.SkillName.Value + " attempt failed.";
                        Resources.Load<GameEvent>("Show Message").Raise();
                        return;
                    }
                    
                    showSkillProgress.Raise();
                    methodInfo.Invoke(this, null);
                }
                else
                {
                    methodInfo.Invoke(this, null);
                    Resources.Load<GameEvent>("Show Message").Raise();
                }
            }
            else
            {
                Debug.LogError("Method '" + functionName + "' not found on " + this);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent<Character>(out Character character))
            {
                Resources.Load<CurrentInteractable>("CurrentInteractable").interactable = this;
                sr.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.TryGetComponent<Character>(out Character character))
            {
                Resources.Load<CurrentInteractable>("CurrentInteractable").interactable = null;
                sr.enabled = false;
            }
        }
    }
}
