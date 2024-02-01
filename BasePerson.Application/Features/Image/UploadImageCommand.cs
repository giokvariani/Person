using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BasePerson.Application.Features.Image
{
    public class UploadImageCommand : IRequest<string>
    {
        public int PersonId { get; set; }
        public IFormFile ImageFile { get; set; }
        public UploadImageCommand(int personId, IFormFile imageFile)
        {
            PersonId = personId;
            ImageFile = imageFile;
        }

        public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
        {
            private readonly IImageService _imageService;
            private readonly IPersonRepository _personRepository;
            public UploadImageCommandHandler(IImageService imageService, IPersonRepository personRepository)
            {
                _imageService = imageService;
                _personRepository = personRepository;   
            }
            public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepository.ReadAsync(request.PersonId);
                if (person == null)
                    throw new EntityNotFoundException();

                var path = await _imageService.UploadImage(request.ImageFile);
                person.Image = path;
                await _personRepository.UpdateAsync(person.Id, person);
                return path;
            }
        }
    }
}
