using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pdc.System.Component
{
    /// <summary>
    /// </summary>
    public class ComponentChannelCollection : IChannelsCollection
    {
        private readonly ICollection<IComponentChannel> _channels;

        /// <summary>
        ///     Initializes a ComponentChannelCollection with the given channels
        /// </summary>
        protected ComponentChannelCollection(IEnumerable<IComponentChannel> collection)
        {
            _channels = new List<IComponentChannel>(collection);
        }

        /// <summary>
        ///     Creates an empty ComponentChannelCollection
        /// </summary>
        protected ComponentChannelCollection()
        {
            _channels = new List<IComponentChannel>();
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///     The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count => _channels.Count;

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool IsReadOnly => _channels.IsReadOnly;

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IComponentChannel> GetEnumerator()
        {
            return _channels.GetEnumerator();
        }

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is
        ///     read-only.
        /// </exception>
        public void Add(IComponentChannel item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Channel with the same name already exists");
            }
            _channels.Add(item);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is
        ///     read-only.
        /// </exception>
        public void Clear()
        {
            _channels.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="item" /> is found in the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />.
        /// </returns>
        public bool Contains(IComponentChannel item)
        {
            return _channels.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an
        ///     <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
        ///     from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have
        ///     zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex" /> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The number of elements in the source
        ///     <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the available space from
        ///     <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.
        /// </exception>
        public void CopyTo(IComponentChannel[] array, int arrayIndex)
        {
            _channels.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="item" /> was successfully removed from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />. This method also
        ///     returns <see langword="false" /> if <paramref name="item" /> is not found in the original
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is
        ///     read-only.
        /// </exception>
        public bool Remove(IComponentChannel item)
        {
            return _channels.Remove(item);
        }

        /// <summary>
        ///     Returns true if the channelName exists, otherwise false
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public bool Contains(string channelName)
        {
            return _channels.Any(c => channelName.Equals(c.Name));
        }

        /// <summary>
        /// </summary>
        /// <param name="channelName"></param>
        /// <exception cref="ChannelNotFoundException"></exception>
        public IComponentChannel this[string channelName]
        {
            get
            {
                if (!Contains(channelName))
                    throw new ChannelNotFoundException(channelName);
                return _channels.Single(c => c.Name.Equals(channelName));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected void AddChannel(string channelName, IActiveComputationUnit unit)
        {
            Add(new ActiveComponentChannel(channelName, unit));
        }

        /// <summary>
        /// </summary>
        /// <param name="channelName"></param>
        /// <typeparam name="TActiveComputationUnit"></typeparam>
        protected void AddChannel<TActiveComputationUnit>(string channelName)
            where TActiveComputationUnit : IActiveComputationUnit
        {
            AddChannel(channelName, Activator.CreateInstance<TActiveComputationUnit>());
        }
    }
}