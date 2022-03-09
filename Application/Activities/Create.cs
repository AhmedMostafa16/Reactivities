using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Activity Activity { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            AppUser user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _userAccessor.GetUsername());
            ActivityAttendee attendee = new()
            {
                AppUser = user,
                Activity = request.Activity,
                IsHost = true
            };

            request.Activity.Attendees.Add(attendee);
            _context.Activities.Add(request.Activity);

            bool result = await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
            return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Faliure("Failed to create activity");
        }
    }
}