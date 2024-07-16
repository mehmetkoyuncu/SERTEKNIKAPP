using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.SampleEntities.Constants;
using Application.Features.Abouts.Constants;
using Application.Features.AboutSubs.Constants;
using Application.Features.Ministrations.Constants;
using Application.Features.UsageAreas.Constants;
using Application.Features.Portfolios.Constants;
using Application.Features.PortfolioCategories.Constants;
using Application.Features.Contacts.Constants;
using Application.Features.Offers.Constants;
using Application.Features.CompanyInfoes.Constants;
using Application.Features.ServiceSummaries.Constants;
using Application.Features.Videos.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region SampleEntities CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = SampleEntitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Abouts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AboutsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AboutsOperationClaims.Read },
                new() { Id = ++lastId, Name = AboutsOperationClaims.Write },
                new() { Id = ++lastId, Name = AboutsOperationClaims.Create },
                new() { Id = ++lastId, Name = AboutsOperationClaims.Update },
                new() { Id = ++lastId, Name = AboutsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AboutSubs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Read },
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Write },
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Create },
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Update },
                new() { Id = ++lastId, Name = AboutSubsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Ministrations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Read },
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Write },
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Create },
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Update },
                new() { Id = ++lastId, Name = MinistrationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UsageAreas CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Read },
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Write },
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Create },
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Update },
                new() { Id = ++lastId, Name = UsageAreasOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Portfolios CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Admin },
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Read },
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Write },
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Create },
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Update },
                new() { Id = ++lastId, Name = PortfoliosOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PortfolioCategories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = PortfolioCategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Contacts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ContactsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Read },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Write },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Create },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Update },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Offers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OffersOperationClaims.Admin },
                new() { Id = ++lastId, Name = OffersOperationClaims.Read },
                new() { Id = ++lastId, Name = OffersOperationClaims.Write },
                new() { Id = ++lastId, Name = OffersOperationClaims.Create },
                new() { Id = ++lastId, Name = OffersOperationClaims.Update },
                new() { Id = ++lastId, Name = OffersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CompanyInfoes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyInfoesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ServiceSummaries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Read },
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Write },
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Create },
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Update },
                new() { Id = ++lastId, Name = ServiceSummariesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Videos CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = VideosOperationClaims.Admin },
                new() { Id = ++lastId, Name = VideosOperationClaims.Read },
                new() { Id = ++lastId, Name = VideosOperationClaims.Write },
                new() { Id = ++lastId, Name = VideosOperationClaims.Create },
                new() { Id = ++lastId, Name = VideosOperationClaims.Update },
                new() { Id = ++lastId, Name = VideosOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
