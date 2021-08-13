using Dtx;
using System.Linq;

namespace Eshop.Controllers
{
    /// <summary>
    /// Restful Products
    /// </summary>
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Route(
        Infrastructure.RouterConstants.Api + "/" + Infrastructure.RouterConstants.Controller)]
    public class ProductsController : Infrastructure.ApiControllerBase
    {
        #region Get All Method

        /// <summary>
		/// Get All
		/// </summary>
		/// <returns>Products List</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (type: typeof(System.Collections.Generic.IList<Models.Product>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

        public
            async
            System.Threading.Tasks.Task
            <Dtx.Result<System.Collections.Generic.IList<Models.Product>>>
            GetAsync()
        {
            FluentResults.Result<System.Collections.Generic.IList<Models.Product>> result =
                new FluentResults.Result<System.Collections.Generic.IList<Models.Product>>();

            await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    var product =
                     Infrastructure.Mock.Products
                    .ToList();

                    result.WithValue(product);
                }
                catch (System.Exception ex)
                {
                    result.WithError(errorMessage: ex.Message);
                }
            });

            return result.ConvertToDtxResult();
        }

        #endregion

        #region Get By Id Method

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <returns>Product</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (type: typeof(System.Collections.Generic.IList<Models.Product>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

        public
            async
            System.Threading.Tasks.Task
            <Dtx.Result<System.Collections.Generic.IList<Models.Product>>>
            GetAsync(int id)
        {
            FluentResults.Result<System.Collections.Generic.IList<Models.Product>> result =
                new FluentResults.Result<System.Collections.Generic.IList<Models.Product>>();

            await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    var product =
                     Infrastructure.Mock.Products
                    .Where(current => current.Id == id)
                    .ToList();

                    result.WithValue(product);
                }
                catch (System.Exception ex)
                {
                    result.WithError(errorMessage: ex.Message);
                }
            });

            return result.ConvertToDtxResult();
        }

        #endregion

        #region Post

        /// <summary>
        /// Post Product
        /// </summary>
        /// <returns>Message</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (type: typeof(string),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        public
            Dtx.Result<string>
            Post([Microsoft.AspNetCore.Mvc.FromBody] string value)
        {
            FluentResults.Result<string> result =
                new FluentResults.Result<string>();

            result.WithValue("Product Add Successfuly!");

            return result.ConvertToDtxResult();
        }

        #endregion

        #region Put

        /// <summary>
        /// Edit Product By Id
        /// </summary>
        /// <returns>Message</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (type: typeof(string),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        public
            Dtx.Result<string>
            Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] string value)
        {
            FluentResults.Result<string> result =
                new FluentResults.Result<string>();

            result.WithValue("Product Edit Successfuly!");

            return result.ConvertToDtxResult();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <returns>Message</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (type: typeof(string),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        public
            Dtx.Result<string>
            Delete(int id)
        {
            FluentResults.Result<string> result =
                new FluentResults.Result<string>();

            result.WithValue("Product Delete Successfuly!");

            return result.ConvertToDtxResult();
        }

        #endregion
    }
}
