using System;
using System.Collections.Generic;
using System.Linq;
using E_Logo.Models;

namespace E_Logo.Models
{

    public static class DTOMappers
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Authenticate  User                                          //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // public static AuthenticateUserDTO AuthenticateDTO(this User user)
        // {
        //     return new AuthenticateUserDTO
        //     {
        //         Id = user.Id,
        //         Pseudo = user.Pseudo,
        //         Email = user.Email,
        //         LastName = user.LastName,
        //         FirstName = user.FirstName,
        //         BirthDate = user.BirthDate,
        //         Reputation = user.Reputation,
        //         Role = user.Role,
        //         Token = user.Token
        //     };
        // }



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