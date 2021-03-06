﻿using System.Collections.Generic;

namespace MonoGameUtils.Particles
{
    /// <summary>
    /// Describes the actions that must be implemented by every Emitter.
    /// </summary>
    public interface IEmitter
    {
        /// <summary>
        /// Emits a new <c>Particle</c> chosen from the provided
        /// list of <c>pParticle</c>s, and returns it to the caller.
        /// </summary>p
        /// <param name="particleTypes">
        /// The list of valid particles to choose from.
        /// </param>
        Particle EmitParticle(List<Particle> particleTypes);
    }
}
