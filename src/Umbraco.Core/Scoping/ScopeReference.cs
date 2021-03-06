namespace Umbraco.Core.Scoping
{
    /// <summary>
    /// References a scope.
    /// </summary>
    /// <remarks>Should go into HttpContext to indicate there is also an IScope in context
    /// that needs to be disposed at the end of the request (the scope, and the entire scopes
    /// chain).</remarks>
    internal class ScopeReference : IDisposeOnRequestEnd // implies IDisposable
    {
        private readonly ScopeProvider _scopeProvider;

        public ScopeReference(ScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        public void Dispose()
        {
            // dispose the entire chain (if any)
            // reset (don't commit by default)
            Scope scope;
            while ((scope = _scopeProvider.AmbientScope) != null)
            {
                scope.Reset();
                scope.Dispose();
            }
        }
    }
}
