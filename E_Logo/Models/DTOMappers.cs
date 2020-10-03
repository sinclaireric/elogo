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
                Email = st.Email,
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
                Email = st.Email,
                //we don't put the password in the DTO for security reasons.
                Firstname = st.Firstname,
                Lastname = st.Lastname,
                Patients = st.Patients.ToDTO()
            };

        }

        //Convertisseur d'une list de SpeechTherapists vers SpeechTherapistsDTO

        public static List<SpeechTherapistDTO> ToDTO(this IEnumerable<SpeechTherapist> sts)
        {
            return sts.Select(s => s.ToDTO()).ToList();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Patients                                                    //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un Patient vers un PatientDTO
        public static PatientDTO ToDTO(this Patient p)
        {

            return new PatientDTO
            {

                Id = p.Id,
                Fullname = p.Fullname,
                // Results = p.Results,
                Diagnostique = p.Diagnostique,
                LastTaskDone = p.LastTaskDone,
                SpeechTherapistID = p.SpeechTherapistID,
                // SpeechTherapistDTO = p.SpeechTherapist.ToDTO(),
            };

        }

        //Convertisseur d'une list de Patients vers PatientDTO

        public static List<PatientDTO> ToDTO(this IEnumerable<Patient> p)
        {
            return p.Select(s => s.ToDTO()).ToList();
        }
    }
}