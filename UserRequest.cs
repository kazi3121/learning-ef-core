public record UserRequest(
    string Name,
    string Email
);

public record UserRequestWithAddress(
    string Name,
    string Email,
    string Address
);