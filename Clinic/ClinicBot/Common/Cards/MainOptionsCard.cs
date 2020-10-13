using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicBot.Common.Cards
{
    public class MainOptionsCard
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }
        private static Activity CreateCarousel()
        {
            var cardCitaMédicas = new HeroCard
            {
                Title = "Citas Médicas",
                Subtitle = "Opciones",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/boletinRas.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Crear cita médica", Value = "Crear cita médica", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "Ver mi cita", Value = "Ver mi cita médica", Type=ActionTypes.ImBack}
                }
            };
            var cardInformacionContacto = new HeroCard
            {
                Title = "Información Contacto",
                Subtitle = "Opciones",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/powerful-hotel-reservation-system.png") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Centro de contacto", Value = "Centro de contacto", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "Sitio web", Value = "https://www.pucese.edu.ec/", Type=ActionTypes.OpenUrl}
                }
            };
            var cardCalificacion = new HeroCard
            {
                Title = "Calificacion",
                Subtitle = "Opciones",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/califacacion-empresas-noticias-infocif.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Calificar Bot", Value = "Calificar Bot", Type=ActionTypes.ImBack},
                 
                }
            };

            var optionAttachments = new List<Attachment>()
            {
                cardCitaMédicas.ToAttachment(),
                cardInformacionContacto.ToAttachment(),
                cardCalificacion.ToAttachment(),
            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
