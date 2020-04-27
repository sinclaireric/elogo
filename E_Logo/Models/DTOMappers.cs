using System;
using System.Collections.Generic;
using System.Linq;
using E_LOGO.Models;

namespace E_LOGO.Models
{

    public static class DTOMappers
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Authenticate  User                                          //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static AuthenticateSpeechTherapistDTO AuthenticateDTO(this SpeechTherapist st)
        {
            return new AuthenticateSpeechTherapistDTO
            {
                Id = st.Id,
                Username = st.Username,
                FirstName = st.Firstname,
                LastName = st.Lastname,
                Token = st.Token
            };
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper SpeechTherapist                                             //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un ST vers un STDTO
        public static SpeechTherapistDTO ToDTO(this SpeechTherapist st)
        {

            return new SpeechTherapistDTO
            {

                Id = st.Id,
                Username = st.Username,
                //we don't put the password in the DTO for security reasons.
                Firstname = st.Firstname,
                Lastname = st.Lastname
            };

        }

        //Convertisseur d'une list de SpeechTherapists vers SpeechTherapistsDTO

        public static List<SpeechTherapistDTO> ToDTO(this IEnumerable<SpeechTherapist> sts)
        {
            return sts.Select(s => s.ToDTO()).ToList();
        }


    }
}