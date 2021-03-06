﻿using System.Collections.Generic;
using System.Linq;
using Telerik.UI.Xaml.Controls.Primitives;
using Telerik.UI.Xaml.Controls.Primitives.Menu;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Telerik.UI.Automation.Peers
{
    public class RadRadialMenuAutomationPeer : RadControlAutomationPeer, IExpandCollapseProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadRadialMenuAutomationPeer"/> class.
        /// Automation Peer for the <see cref="Telerik.UI.Xaml.Controls.Primitives.RadRadialMenu" /> class.
        /// </summary>
        /// <param name="owner">The object that is associated with this AutomationPeer.</param>
        public RadRadialMenuAutomationPeer(RadRadialMenu owner) 
            : base(owner)
        {
        }

        /// <summary>
        /// Gets the state (expanded or collapsed) of the <see cref="Telerik.UI.Xaml.Controls.Primitives.RadRadialMenu" /> control.
        /// </summary>
        /// <returns>The state (expanded or collapsed) of the <see cref="Telerik.UI.Xaml.Controls.Primitives.RadRadialMenu" /> control.</returns>
        public ExpandCollapseState ExpandCollapseState
        {
            get
            {
                return this.RadRadialMenuOwner.IsOpen
                    ? ExpandCollapseState.Expanded
                    : ExpandCollapseState.Collapsed;
            }
        }

        private RadRadialMenu RadRadialMenuOwner
        {
            get
            {
                return this.Owner as RadRadialMenu;
            }
        }

        /// <summary>
        /// Gets a control pattern that is associated with this <see cref="RadRadialMenuAutomationPeer"/>.
        /// </summary>
        /// <param name="patternInterface">One of the enumeration values that indicates the control pattern.</param>
        /// <returns>The object that implements the pattern interface, or null.</returns>
        protected override object GetPatternCore(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.ExpandCollapse)
            {
                return this;
            }
            return base.GetPatternCore(patternInterface);
        }

        /// <inheritdoc />
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Menu;
        }

        /// <inheritdoc />
        protected override string GetClassNameCore()
        {
            return nameof(RadRadialMenu);
        }

        /// <inheritdoc />
        protected override string GetHelpTextCore()
        {
            return nameof(RadRadialMenu);
        }
        
        /// <inheritdoc />
        protected override string GetNameCore()
        {
            var nameCore = base.GetNameCore();
            if (!string.IsNullOrEmpty(nameCore))
                return nameCore;

            return nameof(RadRadialMenu);
        }

        /// <inheritdoc />
        protected override string GetLocalizedControlTypeCore()
        {
            return "rad radial menu";
        }

        /// <inheritdoc />
        protected override string GetAutomationIdCore()
        {
            var automationId = base.GetAutomationIdCore();
            if (!string.IsNullOrEmpty(automationId))
            {
                return automationId;
            }

            return nameof(RadRadialMenu);
        }

        /// <inheritdoc />
        protected override IList<AutomationPeer> GetChildrenCore()
        {
            var children = base.GetChildrenCore().ToList();
            if (children != null && children.Count > 0)
            {
                children.RemoveAll(x => x.GetClassName() == nameof(DecorationItemButton) 
                || x.GetClassName() == nameof(NavigationItemButton));
            }

            return children;
        }

        /// <summary>
        /// Hides all nodes, controls, or content that are descendants of the <see cref="Telerik.UI.Xaml.Controls.Primitives.RadRadialMenu" /> control.
        /// </summary>
        public void Collapse()
        {
            this.RadRadialMenuOwner.IsOpen = false;
        }

        /// <summary>
        /// Displays all child nodes, controls, or content of the <see cref="Telerik.UI.Xaml.Controls.Primitives.RadRadialMenu" /> control.
        /// </summary>
        public void Expand()
        {
            this.RadRadialMenuOwner.IsOpen = true;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        internal void RaiseExpandCollapseAutomationEvent(bool oldValue, bool newValue)
        {
            this.RaisePropertyChangedEvent(
                ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty,
                oldValue ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed,
                newValue ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
        }
    }
}
