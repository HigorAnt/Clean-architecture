using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;
public class CategoryUnitTest1
{
    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
    }
    [Fact]
    public void CreateCategory_InvalidIdvalue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(0, "Category Name");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
    }
    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
    }
    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
    }
    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should().Throw<DomainExceptionValidation>();
    }
}
