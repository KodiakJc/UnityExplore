using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Gamekit2D
{
    [RequireComponent(typeof(Slider))]
    public class MixerSliderLink : MonoBehaviour
    {
        public AudioMixer mixer;
        public string mixerParameter;

        public float maxAttenuation = 0.0f;
        public float minAttenuation = -80.0f;

        protected Slider m_Slider;

        private FMOD.Studio.EventInstance OnSlider_fmod;

        void Awake ()
        {
            m_Slider = GetComponent<Slider>();

            float value;
            mixer.GetFloat(mixerParameter, out value);

            m_Slider.value = (value - minAttenuation) / (maxAttenuation - minAttenuation);

            m_Slider.onValueChanged.AddListener(SliderValueChange);
            
            OnSlider_fmod = FMODUnity.RuntimeManager.CreateInstance("event:/UI/sliders");
            OnSlider_fmod.start();

        }


        void SliderValueChange(float value)
        {
            mixer.SetFloat(mixerParameter, minAttenuation + value * (maxAttenuation - minAttenuation));

           OnSlider_fmod.setParameterByName("OnSlider", 1.0f);

            string vcaPatch = "vca:/VCA_music";
            FMOD.Studio.VCA vca = FMODUnity.RuntimeManager.GetVCA(vcaPatch);
            vca.setVolume(value);
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnSlider_fmod.setParameterByName("OnSlider", 0.0f);
            }
        }
    }
}