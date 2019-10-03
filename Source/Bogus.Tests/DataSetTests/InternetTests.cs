﻿using System.Linq;
using Bogus.DataSets;
using FluentAssertions;
using Xunit;
using Z.ExtensionMethods;

namespace Bogus.Tests.DataSetTests
{
   public class InternetTests : SeededTest
   {
      public InternetTests()
      {
         internet = new Internet();
      }

      private readonly Internet internet;

      [Fact]
      public void can_generate_a_password()
      {
         var pw = internet.Password();
         pw.Should().Be("YmaMy0eWbv");

         var pw2 = internet.Password(regexPattern: @"\W");
         pw2.Should().Be(@""">({=*`/{]");
      }

      [Fact]
      public void can_generate_an_example_email()
      {
         var email = internet.ExampleEmail();

         email.Should().EndWith("@example.com");
         email.GetBefore("@").Should().Contain(".");
      }

      [Fact]
      public void can_generate_mac_address()
      {
         internet.Mac().Should().Be("9a:1c:d0:a5:09:9f");
      }

      [Fact]
      public void can_generate_mac_address_with_separator()
      {
         internet.Mac("_").Should().Be("9a_1c_d0_a5_09_9f");
      }

      [Fact]
      public void can_get_a_domain_name()
      {
         internet.DomainName().Should().Be("lee.com");
      }

      [Fact]
      public void can_get_a_domain_suffix()
      {
         internet.DomainSuffix().Should().Be("name");
      }

      [Fact]
      public void can_get_a_random_ip_address()
      {
         internet.Ip().Should().Be("154.28.208.165");
      }

      [Fact]
      public void can_get_a_random_ipv6_address()
      {
         internet.Ipv6().Should().Be("da23:9c4c:e0c4:2dd7:e3c4:a896:17f2:55b2");
      }

      [Fact]
      public void can_get_an_email()
      {
         var email = internet.Email();

         email.Should().Be("Bernhard.Schultz@yahoo.com");
      }

      [Fact]
      public void can_get_an_username()
      {
         var user = internet.UserName();

         user.Should().Be("Lee_Brekke3");
      }

      [Fact]
      public void can_get_avatar()
      {
         var avatar = internet.Avatar();

         avatar.Should().Be("https://s3.amazonaws.com/uifaces/faces/twitter/nasirwd/128.jpg");
      }

      [Fact]
      public void can_get_html_color()
      {
         internet.Color().Should().Be("#4d0e68");
      }

      [Fact]
      public void can_get_color_in_format()
      {
         internet.Color(format:ColorFormat.Rgb).Should().Be("rgb(77,14,104)");
      }

      [Fact]
      public void can_get_color_in_grayscale()
      {
         internet.Color(grayscale: true).Should().Be("#4d4d4d");
      }

      [Fact]
      public void can_get_url_with_path()
      {
         internet.UrlWithPath().Should().Be("https://bernhard.net/movies--clothing/bedfordshire");
      }

      [Fact]
      public void can_get_url_with_path_and_specific_domain()
      {
         internet.UrlWithPath(domain: "bitarmory.com").Should().Be("https://bitarmory.com/bluetooth");
      }

      [Fact]
      public void can_get_url_with_path_and_extension()
      {
         internet.UrlWithPath(fileExtension: "ext").Should().Be("https://bernhard.net/movies--clothing/bedfordshire.ext");
      }

      [Fact]
      public void can_gets_a_domain_word()
      {
         internet.DomainWord().Should().Be("lee");
      }

      [Fact]
      public void can_make_email_with_custom_options()
      {
         var email = internet.Email(provider: "x.y.z.com");

         email.Should().Be("Lee_Brekke3@x.y.z.com");

         email = internet.Email("cowboy");

         email.Should().Be("cowboy.Beatty30@yahoo.com");
      }


      [Fact]
      public void can_pick_random_browser()
      {
         Enumerable.Range(1, 200).Select(
               i => internet.UserAgent())
            .Dump();
      }

      [Fact]
      public void can_get_path()
      {
         internet.Path().Should().Be("/soft/deposit");
      }

      [Fact]
      public void can_get_path_with_extension()
      {
         internet.Path(".ext").Should().Be("/soft/deposit.ext");
      }

      [Fact]
      public void can_get_path_with_extension_adds_period_if_needed()
      {
         internet.Path("ext").Should().Be("/soft/deposit.ext");
      }

      [Theory]
      [InlineData("Анна", "Фомина", "Анна11", 1337)]
      [InlineData("Анна", "Фомина", "Анна_Фомина13", 228)]
      [InlineData("Анна", "Фомина", "Анна.Фомина", 302)]
      public void can_get_username_with_unicode_characters(string first, string last, string expected, int seed)
      {
         internet.Random = new Randomizer(seed);
         internet.UserNameUnicode(first, last).Should().Be(expected);
      }
   }
}