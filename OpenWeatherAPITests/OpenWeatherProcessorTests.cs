using System;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        #region (--) T01 Affiche exceptMess APIkey (valide / null)  --> GetOneCallAsync
        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null

        public void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {

        }
        #endregion


        #region (--) T02 Affiche exceptMess APIkey (vide / null)
        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.

        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        { 


        }
        #endregion


        #region (--) T03 Affiche Exception Message Client HTTP not initialize
        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.

        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {

        }
        #endregion


        #region (--) T04  Affiche Exception Message 
        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.

        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {


        }
        #endregion
    }
}
